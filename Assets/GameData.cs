using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    private const string money = "Money";
    public float Money
    {
        get { return PlayerPrefs.GetFloat(money); }
        set { PlayerPrefs.SetFloat(money, value); }
    }
}