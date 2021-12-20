using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyTextUpdater : MonoBehaviour
{
    private PlayerData playerData = new PlayerData();

    public TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + playerData.Money.ToString();
    }
}
