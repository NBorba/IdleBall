using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransactions
{
    private GameData gameData = new GameData();
    private PlayerData playerData = new PlayerData();

    public bool BuyBall() {
        if (CanBuyBall()) {
            ExchangeMoneyForBall();
            return true;
        } else {
            return false;
        }
    } 

    public bool CanBuyBall() {
        return playerData.Money >= gameData.BallPrice;
    }

     private void ExchangeMoneyForBall() {
        var ballPrice = gameData.BallPrice;
        playerData.Balls += 1;
        playerData.Money -= ballPrice;
    }
}
