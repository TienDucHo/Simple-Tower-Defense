using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CurrencySystem : MonoBehaviour
{
    // Fields

    // Currency Text UI
    public TMP_Text txt_currencyCount;

    // Default Currency
    public int defaultCurrency;

    // Current Currency
    public int currentCurrency;

    public float interval = 5.5f;

    // Methods

    // Set default values
    public void Init()
    {
        currentCurrency = defaultCurrency;
        UpdateUI();
        StartCoroutine(Interval());
    }

    public void ResetCurrencyCount() { currentCurrency = defaultCurrency; UpdateUI(); }

    // Gain currency
    public void GainCurrency(int val)
    {
        currentCurrency += val;
        UpdateUI();
    }

    // Lose currency
    public bool UseCurrency(int val)
    {
        if (!EnoughCurrency(val))
            return false;
        currentCurrency -= val;
        UpdateUI();
        return true;
    }

    // Check emptiness
    public bool EnoughCurrency(int val)
    {
        return currentCurrency >= val;
    }

    // Update text UI
    void UpdateUI()
    {
        txt_currencyCount.text = currentCurrency.ToString();
    }

    public void UseTest()
    {
        Debug.Log(UseCurrency(3));
    }

    IEnumerator Interval()
    {
        yield return new WaitForSeconds(interval);
        GainCurrency(1);
        UpdateUI();
        StartCoroutine(Interval());
    }
}
