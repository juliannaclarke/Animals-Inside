using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject menuPanel;
    public GameObject setupPanel;
    public void animalsBegin()
    {
        //if they check skip tutorial then load main level
        SceneManager.LoadScene("Tutorial");
    }
    public void returnToMenu()
    {
        //if they check skip tutorial then load main level
        SceneManager.LoadScene("Menu");
    }

    public void credits()
    {
        if(creditsPanel != null)
        {
            creditsPanel.SetActive(true);
            menuPanel.SetActive(false);
        }
    }

    public void instructions()
    {
        setupPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void menu()
    {
        setupPanel.SetActive(false);
        creditsPanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
