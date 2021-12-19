using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMoneyUI : MonoBehaviour
{
    private TextMeshProUGUI gameMoneyText;

    // Start is called before the first frame update
    void Start()
    {
        gameMoneyText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gameMoneyText.text = new GameData().Money.ToString();
    }
}
