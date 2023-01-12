using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TMP_InputField playerNameInputField;
    public GameObject mainMenu;
    public GameObject levelMenu;

    private void Start()
    {
    }
    public void Continue() {
        if (playerNameInputField.text != string.Empty)
        {
            PlayerStatus.instance.playerName = playerNameInputField.text;
            PlayerStatus.instance.LoadStats();
            mainMenu.SetActive(false);
            levelMenu.SetActive(true);
        }
        else
        {
            // TODO: Set up a dialog here
            Debug.Log("Please Enter your name");
        }
    }
}
