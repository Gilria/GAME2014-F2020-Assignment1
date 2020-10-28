using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuildController : MonoBehaviour
{
    public static int currentTurret;
    public static int goldLeft=200;
    public static int numOfLives = 4;
    public static int numOfKills = 0;

    public Text timeLeftText;

    private float timeLeft=180;

    public GameObject[] lives;

    public Text goldText;


    private void Start()
    {
    goldLeft = 200;
    numOfLives = 4;
    numOfKills = 0;
    Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    public void ChangeTurretType(int type)
    {
        currentTurret = type;
        Debug.Log("Current Turret Set To: " + currentTurret);
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        timeLeftText.text = "TimeLeft:"+(int)timeLeft;
        if (timeLeft <= 0)
        {
            GameOver();
            
        }

        LiveCheck();
        goldText.text = goldLeft.ToString();

    }



    void LiveCheck()
    {
        if (numOfLives < lives.Length)
        {
            if (numOfLives < 0)
            {
                GameOver();
            }
            else
            {
                Destroy(lives[numOfLives]);
            }
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(3);
    }

}
