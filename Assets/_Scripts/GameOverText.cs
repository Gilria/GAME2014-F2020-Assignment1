using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameOverText : MonoBehaviour
{
    // Start is called before the first frame update
    private Text gameOverText;

    void Start()
    {
        gameOverText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        gameOverText.text = "Congratulations!\n"+"You Killed " + BuildController.numOfKills + " Enemies In This Round!";
    }
}
