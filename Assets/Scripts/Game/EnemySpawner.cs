using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    public int maximumEnemies = 15;
    public int enemyCount = 0;
    Coroutine spawnCoroutine;

    void Awake() { instance = this; }

    // Enemy prefabs
    public List<GameObject> prefabs;
    
    // Enemy spawn root points
    public List<Transform> spawnPoints;
    
    // Enemy spawn interval
    public float spawnInterval = 2f;

    // List of spawned enemies
    public List<GameObject> enemies;

    public void Reset()
    {
        enemies.ForEach(e => { Destroy(e); });
    }


    public void StartSpawning()
    {
        //Call the spawn coroutine
        spawnCoroutine = StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        //Call the spawn method
        
        SpawnEnemy();
        //Wait spawn interval
        yield return new WaitForSeconds(spawnInterval);
        //Recall the same coroutine
        if (enemies.Count >= maximumEnemies) StopCoroutine(spawnCoroutine);
        else 
            spawnCoroutine = StartCoroutine(SpawnDelay());
    }

    void SpawnEnemy()
    {
        //Randomize the enemy spawned
        int randomPrefabID = Random.Range(0, prefabs.Count);
        //Randomize the spawn point 
        int randomSpawnPointID = Random.Range(0, spawnPoints.Count);
        //Instantiate the enemy prefab
        GameObject spawnedEnemy = Instantiate(prefabs[randomPrefabID], spawnPoints[randomSpawnPointID]);
        enemies.Add(spawnedEnemy);
        enemyCount++;
    }

    public void CheckWin()
    {
        if (enemyCount == 0)
        {
            GameManager.instance.gameOverOverlay.SetActive(true);
            Time.timeScale = 0;
            GameManager.instance.gameOverOverlay.GetComponent<GameOver>().Win();
        }
    }

}
