using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    // Life Text UI
    public TMP_Text txt_healthCount;

    public int healthCount;
    public int defaultHealthCount;
    // Initiate the Health system (reset health count)
    public void Init()
    {
        healthCount = defaultHealthCount;
        txt_healthCount.text = healthCount.ToString();
    }

    // Lose health count
    public void LoseHealth()
    {
        if (healthCount == 0) return;
        healthCount--; 
        txt_healthCount.text = healthCount.ToString();
        CheckDeath();
    }

    public void CheckDeath()
    {
        if (healthCount > 0) return;
        Debug.Log("You Lose");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
