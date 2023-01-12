using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public string playerName;
    public int levelUnlocked;
    public static PlayerStatus instance;
    // Start is called before the first frame update
    void Awake()
    {  
        instance = this;
    }

    public void LoadStats()
    {
        levelUnlocked = PlayerPrefs.GetInt("Level" + playerName);
    }

    public void SaveStats()
    {
        PlayerPrefs.SetInt("Level" + playerName, levelUnlocked);
    }
}
