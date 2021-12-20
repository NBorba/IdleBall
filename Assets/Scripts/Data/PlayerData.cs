using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    // KEYS
    private const string key_player_balls = "KEY_PLAYER_BALLS";
    private const string key_player_money = "KEY_PLAYER_MONEY";
    private const string key_player_critical_chance = "KEY_PLAYER_CRITICAL_CHANCE";

    public int Balls 
    {
        get { return PlayerPrefs.GetInt(key_player_balls); }
        set { PlayerPrefs.SetInt(key_player_balls, value); }
    }

    public float Money
    {
        get { return PlayerPrefs.GetFloat(key_player_money); }
        set { PlayerPrefs.SetFloat(key_player_money, value); }
    }

    public float CriticalChance 
    {
        get { return PlayerPrefs.GetFloat(key_player_critical_chance); }
        set { PlayerPrefs.SetFloat(key_player_critical_chance, value); }
    }
}