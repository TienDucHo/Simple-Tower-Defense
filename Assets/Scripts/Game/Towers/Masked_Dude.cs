using System.Collections;
using UnityEngine;

public class Masked_Dude : MonoBehaviour
{
    public int cost;
    public int health;
    public int incomeValue;
    public float interval;

    public void Start()
    {
    }

    public void LoseHealth()
    {
        health--;
        if (health <= 0) Die();
    }

    public void Die()
    {
        Debug.Log("Pink Guy is dead");
        Destroy(gameObject);
    }
}
