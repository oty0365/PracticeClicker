using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Select : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    private void Update()
    {
        tmp.text = "누군가의 최고기록: "+PlayerPrefs.GetFloat("Highest")+"cps";
    }

    public void GameStrat()
    {
        SceneManager.LoadScene(2);
    }
    public void ResetPlayerClicks()
    {
        PlayerPrefs.SetFloat("Highest",0);
    }
    public void GameEnd()
    {
        Application.Quit();
    }
    
}
