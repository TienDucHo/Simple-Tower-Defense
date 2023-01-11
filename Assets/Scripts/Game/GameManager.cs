using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Spawner spawner;
    public HealthSystem healthSystem;
    public CurrencySystem currencySystem;
    public GameObject gameOverOverlay;
    public EnemySpawner enemySpawner;

    void Awake() 
    { 
        instance = this;
    }
    
    void Start()
    {
        GetComponent < HealthSystem > ().Init();
        GetComponent < CurrencySystem > ().Init();
        StartCoroutine(WaveStartDelay());
    }

    public void Restart()
    {
        GetComponent<HealthSystem>().ResetHealthCount();
        GetComponent<CurrencySystem>().ResetMoney();
        GetComponent<Spawner>().Reset();
        GetComponent<EnemySpawner>().Reset();
        gameOverOverlay.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(WaveStartDelay());
    }

    IEnumerator WaveStartDelay()
    {
        //Wait for X seconds
        yield return new WaitForSeconds(2f);
        //Start the enemy spawning
        GetComponent<EnemySpawner>().StartSpawning();
    }
}
