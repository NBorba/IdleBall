using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyButtonUpdater : MonoBehaviour
{
    private GameData gameData = new GameData();
    private PlayerTransactions playerTransactions = new PlayerTransactions();

    public Button buyButton;
    public TextMeshProUGUI buyButtonText;

    // Start is called before the first frame update
    void Start()
    {
        buyButton.onClick.AddListener(BuyButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        buyButton.interactable = playerTransactions.CanBuyBall();
        buyButtonText.text = "Buy ($" + gameData.BallPrice.ToString() + ")";
    }

    void BuyButtonClicked() {
        var success = playerTransactions.BuyBall();
        Debug.Log("Ball bought: " + success.ToString());
    }
}
