using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    private const float DEFAULT_BALL_PRICE = 200f;

    // KEYS
    private const string key_game_ball_price = "KEY_GAME_BALL_PRICE";

    public float BallPrice 
    {
        get 
        { 
            var price = PlayerPrefs.GetFloat(key_game_ball_price); 
            if (price == 0) 
            {
                return DEFAULT_BALL_PRICE;
            } 
            else 
            {
                return price; 
            } 
            
        }
        set { PlayerPrefs.SetFloat(key_game_ball_price, value); }
    }
}