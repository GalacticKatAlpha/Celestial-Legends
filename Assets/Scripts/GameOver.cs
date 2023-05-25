using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("BACK TO MENU");
    }
}
