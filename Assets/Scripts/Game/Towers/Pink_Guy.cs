using System.Collections;
using UnityEngine;

public class Pink_Guy : Tower
{
    public int incomeValue;
    public float interval;
    public GameObject obj_coin;
    [SerializeField] private AudioSource coinSFX;

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
        GameManager.instance.currencySystem.GainMoney(incomeValue);
        StartCoroutine(CoinIndication());
    }

    IEnumerator CoinIndication()
    {
        obj_coin.SetActive(true);
        coinSFX.Play();
        yield return new WaitForSeconds(0.5f);
        obj_coin.SetActive(false);
    }
}
