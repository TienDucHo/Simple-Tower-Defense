using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    // Life Text UI
    public TMP_Text txt_healthCount;

    public int healthCount;
    public int defaultHealthCount;
    public GameObject gameOverOverlay;
    // Initiate the Health system (reset health count)
    public void Init()
    {
        healthCount = defaultHealthCount;
        txt_healthCount.text = healthCount.ToString();
    }

    public void ResetHealthCount() { 
        healthCount = defaultHealthCount;
        txt_healthCount.text = healthCount.ToString();
    }

    // Lose health count
    public void LoseHealth(int value = 1)
    {
        if (healthCount == 0) return;
        healthCount -= value; 
        txt_healthCount.text = healthCount.ToString();
        CheckDeath();
    }

    public void CheckDeath()
    {
        if (healthCount > 0) return;
        gameOverOverlay.SetActive(true);
        Time.timeScale = 0;
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
