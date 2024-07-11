using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Selection : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("ClickMode",0);
        
    }

    public void Zero()
    {
        PlayerPrefs.SetInt("ClickMode",2);
        SceneManager.LoadScene(1);
    }
    public void First()
    {
        PlayerPrefs.SetInt("ClickMode",3);
        SceneManager.LoadScene(1);
    }
    public void Scecond()
    {
        PlayerPrefs.SetInt("ClickMode",6);
        SceneManager.LoadScene(1);
    }
    public void Third()
    {
        PlayerPrefs.SetInt("ClickMode",11);
        SceneManager.LoadScene(1);
    }
}
