using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    // List of towers (prefab) that will instantiate
    public List<GameObject> towerPrefabs;

    // List of towers (UI)
    public List<Image> towerUIs;

    // Transform of the spawning towers (Root Object)
    public Transform spawnTowerRoot;
    
    // ID of tower to spawn
    int spawnID = -1;


    // List of spawned Towers;
    public List<GameObject> towers;

    // Spawn Points Tilemap
    public Tilemap spawnTilemap;


    public void Reset()
    {
        towers.ForEach(t => Destroy(t));
    }

    public void SelectTower(int id) 
    {
        if (spawnID != -1)
        {
            towerUIs[spawnID].color = new Color(0.4f, 0.4f, 0.4f);
        }
        // Set the spawn ID
        spawnID = id;

        // Highlight the selected Tower
        towerUIs[id].color = Color.white;
    }

    public void DeselectTower() 
    {
        if (spawnID != -1)
        {
            towerUIs[spawnID].color = new Color(0.4f, 0.4f, 0.4f);
        }
        spawnID = -1;
    }

    void DetectSpawnPoint()
    {
        // Detect mouse click (Touch)
        if (!Input.GetMouseButtonDown(0)) return;
        // Get the world space position of the mouse
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Get the position of the cell in the tilemap
        var cellPosDefault = spawnTilemap.WorldToCell(mousePos);
        // Get the center position of the cell
        var cellPosCenter = spawnTilemap.GetCellCenterWorld(cellPosDefault);
        // Check if we can spawn in that cell (collider)
        if (spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
        {
            // Get the tower cost
            int towerCost = GetTowerCost(spawnID);
            // Check if not enough currency
            if (!GameManager.instance.currencySystem.EnoughCurrency(towerCost)) 
            {
                Debug.Log("Not enough money");
                return;
            }
            //Reduce the currency
            GameManager.instance.currencySystem.UseCurrency(towerCost);
            // Spawn the Tower
            SpawnTower(cellPosCenter);
            // Disable that collider
            spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
        }
        // Do nothing if no
        // Spawn the collider if yes
    }

    public int GetTowerCost(int id)
    {
        switch (id)
        {
            case 0: return towerPrefabs[0].GetComponent<Pink_Guy>().cost;
            case 1: return towerPrefabs[1].GetComponent<Masked_Dude>().cost;
            case 2: return towerPrefabs[2].GetComponent<Ninja_Frog>().cost;
            default: return 0;
        }
    }

    void SpawnTower(Vector3 position)
    {
        GameObject tower = Instantiate(towerPrefabs[spawnID], spawnTowerRoot);
        tower.transform.position = position;
        towers.Add(tower);
        DeselectTower();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanSpawn()) return;
        DetectSpawnPoint();   
    }

    bool CanSpawn()
    {
        if (spawnID == -1) return false;
        return true;
    }

    public void RevertCellState(Vector3Int pos)
    {
        spawnTilemap.SetColliderType(pos, Tile.ColliderType.Sprite);
    }
}
