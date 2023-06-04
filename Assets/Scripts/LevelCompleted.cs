using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{

    public string nextLevel;
    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
