﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void SwitchToGame()
    {
        SceneManager.LoadScene(1);
    }
    public void SwitchToIntroduction()
    {
        SceneManager.LoadScene(2);
    }
    public void SwitchToOver()
    {
        SceneManager.LoadScene(3);
    }
}
