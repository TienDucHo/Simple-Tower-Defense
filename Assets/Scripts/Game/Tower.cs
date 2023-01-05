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
    public AudioClip dieSFX;
    public Animator animator;
    [SerializeField] private AudioSource hitSFX;


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
        hitSFX.Play();
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(dieSFX, new Vector3(0, 0, -10), 1f);
            animator.SetTrigger("Die");
            StartCoroutine(Die());
            return true;
        }
        return false;
    }

    protected virtual IEnumerator Die()
    {
        FindObjectOfType<Spawner>().RevertCellState(cellPosition);
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }

}
