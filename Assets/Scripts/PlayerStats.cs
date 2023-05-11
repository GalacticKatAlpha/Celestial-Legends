using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int Money;
    public int startMoney = 350;

    public static int Health;
    public int startingHealth = 400;

    private void Start()
    {
        Money = startMoney;
        Health = startingHealth;
    }

}
