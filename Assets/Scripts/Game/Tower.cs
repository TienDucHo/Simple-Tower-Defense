using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Tower : MonoBehaviour
{

    public int health;
    public int cost;
    private Vector3Int cellPosition;


    protected virtual void Start()
    {
        
    }

    public virtual void Init(Vector3Int cellPos)
    {
        cellPosition = cellPos;
    }

    //Lose Health
    public virtual bool LoseHealth(int amount)
    { 
        health -= amount;
        GetComponent<Animator>().SetTrigger("GettingHit");
        if (health <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    protected virtual void Die()
    {
        FindObjectOfType<Spawner>().RevertCellState(cellPosition);
        Destroy(gameObject);
    }

}
