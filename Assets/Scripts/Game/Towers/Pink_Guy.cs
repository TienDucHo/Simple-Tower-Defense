using System.Collections;
using UnityEngine;

public class Pink_Guy : MonoBehaviour
{
    public int cost;
    public int health;
    public int incomeValue;
    public float interval;
    // Coin Image object
    public GameObject coin;

    public void Start()
    {
        StartCoroutine(Interval());
    }
    IEnumerator Interval()
    {
        yield return new WaitForSeconds(interval);
        // Trigger the income increase
        IncreaseIncome();
        StartCoroutine(Interval());

    }

    public void IncreaseIncome()
    {
        GameManager.instance.currencySystem.GainCurrency(incomeValue);
        StartCoroutine(CoinIndication());
    }

    // UI Indication

    IEnumerator CoinIndication()
    {
        coin.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        coin.SetActive(false);
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
