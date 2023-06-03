using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI coinText;

    public void OnTriggerEnter(Collider col)
    {
        Debug.Log("Trigger!");
        if (col.gameObject.tag == "Coin")
        {
            Debug.Log("Collected a coin!");
            coins = coins + 1;
            Destroy(col.gameObject);
            coinText.text = "Collected Coins: " + coins.ToString() + "/5";
        }
        else if (col.gameObject.tag == "Guard")
        {
            Debug.Log("Busted!");
        }
    }
}
