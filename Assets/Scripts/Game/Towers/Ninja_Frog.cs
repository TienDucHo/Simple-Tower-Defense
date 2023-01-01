using System.Collections;
using UnityEngine;

public class Ninja_Frog : MonoBehaviour
{
    public int cost;
    public int health;
    public int damage;
    public float interval;
    // Bullet
    public GameObject bulletPrefab;

    public void Start()
    {
        StartCoroutine(AttackDelay());
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(interval);
        ShootItem();
        StartCoroutine(AttackDelay());
    }

    void ShootItem()
    {
        GameObject bulletItem = Instantiate(bulletPrefab, transform);
        bulletItem.GetComponent<BulletItem>().Init(damage);
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
