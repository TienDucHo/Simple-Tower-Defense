using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCostDisplay : MonoBehaviour
{
    public int towerID;
    public int towerCost;
    // Start is called before the first frame update
    void Start()
    {
        towerCost = GameManager.instance.spawner.GetTowerCost(towerID);
        GetComponent<TMPro.TMP_Text>().text = towerCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
