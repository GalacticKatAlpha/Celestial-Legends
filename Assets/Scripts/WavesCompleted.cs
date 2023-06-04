using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WavesCompleted : MonoBehaviour
{
    public TextMeshProUGUI wavesCompText;

    private void OnEnable()
    {
        wavesCompText.text = PlayerStats.Rounds.ToString();
    }
}
