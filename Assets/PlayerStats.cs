using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerStats : MonoBehaviour
{
    public static int money;
    public static int startMoney = 400;


    public void Start()
    {
        money = startMoney;
    }
}
