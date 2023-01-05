using System.Collections;
using UnityEngine;

public class Ninja_Frog : Tower
{
    //FIELDS
    //damage
    public int damage;
    //prefab (shooting item)
    public GameObject prefab_shootItem;
    //shoot interval
    public float interval;
    [SerializeField] private AudioSource bulletSFX;


    //METHODS
    //init (start the shooting interval)
    protected override void Start()
    {
        //start the shooting interval IEnum
        StartCoroutine(ShootDelay());
    }
    //Interval for shooting
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(interval);
        ShootItem();
        StartCoroutine(ShootDelay());
    }
    //Shoot an item
    void ShootItem()
    {
        //Instantiate shoot item
        GameObject shotItem = Instantiate(prefab_shootItem, transform);
        //Set its values  
        shotItem.GetComponent<BulletItem>().Init(damage);
        bulletSFX.Play();
    }
}
