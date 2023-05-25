using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;

    public GameObject gameOverUI;

    private void Start()
    {
        gameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameIsOver)
        {
            return;
        }

        if(Input.GetKeyDown("k"))
        {
            EndGame();
        }

        if (PlayerStats.Health <= 0) 
        { 
            EndGame();
        }
    }

    private void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
