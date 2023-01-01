using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : MonoBehaviour
{
    public Transform graphics;
    public int damage;
    public float flySpeed;
    public float rotateSpeed;

    //public LayerMask enemyPlayer;

    public void Init(int dmg)
    {
        damage = dmg;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Shot the enemy");
            //collision.GetComponent<Enemy>().LoseHealth();
            Destroy(gameObject);
        }
        if (collision.tag == "Out")
        {
            Destroy(gameObject);
        }
    }

    //Handle rotation and flying
    void Update()
    {
        Rotate();
        FlyForward();
    }

    void Rotate()
    {
        graphics.Rotate(new Vector3(0, 0, -rotateSpeed * Time.deltaTime));
    }

    void FlyForward()
    {
        transform.Translate(transform.right * flySpeed * Time.deltaTime);
    }
}
