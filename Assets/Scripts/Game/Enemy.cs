using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health, attackPower;
    public float moveSpeed;

    public Animator animator;
    public float attackInterval;
    Coroutine attackOrder;
    public Tower detectedTower;
    public bool isAttackingHome = false;

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        if (!detectedTower && !isAttackingHome)
        {
            animator.ResetTrigger("Attack");
            Move();
        }
    }

    IEnumerator Attack()
    {
        if (!animator) StopCoroutine(attackOrder);
        else
        {
            animator.SetTrigger("Attack");
            //Wait attackInterval 
            yield return new WaitForSeconds(attackInterval);
            //Attack Again
            attackOrder = StartCoroutine(Attack());
        } 
        
    }

    //Moving forward
    void Move()
    {
        transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
    }

    public void InflictDamage()
    {
        if (isAttackingHome) {
            GameManager.instance.healthSystem.LoseHealth();
            StopCoroutine(attackOrder);
            Destroy(gameObject);
        }
        if (!detectedTower)
            return;
        bool towerDied = detectedTower.LoseHealth(attackPower);

        if (towerDied)
        {
            detectedTower = null;
            StopCoroutine(attackOrder);
        }
    }

    //Lose health
    public void LoseHealth()
    {
        //Decrease health value
        health--;
        // Getting Hit Animation
        animator.SetTrigger("Hurt");
        //Check if health is zero => destroy enemy
        if (health <= 0)
        {
            GameManager.instance.enemySpawner.enemyCount--;
            Destroy(gameObject);
            GameManager.instance.enemySpawner.CheckWin();
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (detectedTower)
            return;

        if (collision.tag == "Tower")
        {
            detectedTower = collision.GetComponent<Tower>();
            attackOrder = StartCoroutine(Attack());
        }

        if (collision.tag == "Home")
        {
            isAttackingHome = true;
            attackOrder = StartCoroutine(Attack());
        }
    }
}
