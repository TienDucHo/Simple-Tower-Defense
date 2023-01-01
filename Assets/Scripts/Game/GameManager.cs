using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Spawner spawner;
    public HealthSystem healthSystem;
    public CurrencySystem currencySystem;

    void Awake() 
    { 
        instance = this; 
    }
    
    void Start()
    {
        GetComponent < HealthSystem > ().Init();
        GetComponent < CurrencySystem > ().Init();
    }
}
