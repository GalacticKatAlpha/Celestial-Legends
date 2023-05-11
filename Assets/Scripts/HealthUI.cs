using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{

    public TextMeshProUGUI healthText;


    void Update()
    {
        healthText.text = PlayerStats.Health.ToString() + " HP";
    }
}
