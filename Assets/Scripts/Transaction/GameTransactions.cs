using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTransactions
{
    private System.Random random = new System.Random();
    private GameData gameData = new GameData();
    private PlayerData playerData = new PlayerData();

    public BounceData OnBallBounced() {
        var isCritical = IsCriticalBounce();
        var reward = CalculateReward(IsCriticalBounce());

        GiveMoneyToPlayer(reward);

        return new BounceData(reward, isCritical);
    } 

    private float CalculateReward(bool isCritical) {
        var baseReward = 1f;
        var criticalValue = 2f;

        if (isCritical) {
            return baseReward * criticalValue;
        }

        return baseReward;
    }

    private bool IsCriticalBounce() {
        return (float)random.NextDouble() < playerData.CriticalChance;
    }

    private void GiveMoneyToPlayer(float money) {
        playerData.Money += money;
    }

    public class BounceData {
        public BounceData(float reward, bool isCritical) {
            this.Reward = reward;
            this.IsCritical = isCritical; 
        }

        public float Reward { get; private set; }
        public bool IsCritical { get; private set; }
    }
}
