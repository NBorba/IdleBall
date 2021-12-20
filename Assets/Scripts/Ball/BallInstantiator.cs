using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInstantiator : MonoBehaviour
{
    private PlayerData playerData = new PlayerData();

    public GameObject ballPrefab;

    private int spawnedBalls = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerData.Balls = 1;
        //playerData.Money = 200f;
        playerData.CriticalChance = 10f / 100f; // 10% chance
    }

    // Update is called once per frame
    void Update()
    {
        InstantiatePlayerBalls();
    }

    private void InstantiatePlayerBalls() 
    {
        while (spawnedBalls < playerData.Balls) 
        {
            InstantiateBall();
        }
    }

    private void InstantiateBall() {
        var ball = Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        ball.tag = Tags.BALL;

        spawnedBalls++;
    }
}
