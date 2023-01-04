using System.Collections;
using UnityEngine;

public class Pink_Guy : Tower
{
    public int incomeValue;
    public float interval;
    public GameObject obj_coin;

    protected override void Start()
    {
        StartCoroutine(Interval());
    }

    IEnumerator Interval()
    {
        yield return new WaitForSeconds(interval);
        IncreaseIncome();
        StartCoroutine(Interval());
    }

    public void IncreaseIncome()
    {
        GameManager.instance.currencySystem.GainCurrency(incomeValue);
        StartCoroutine(CoinIndication());
    }

    IEnumerator CoinIndication()
    {
        obj_coin.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        obj_coin.SetActive(false);
    }
}
