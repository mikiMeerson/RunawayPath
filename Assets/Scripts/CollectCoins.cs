using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public int coins;
    public TextMeshProUGUI coinText;
    public GameObject victoryMenu;
    public GameObject loseMenu;
    public int coinVictoryAmount = 5;

    public void Start() {
        UpdateText();
    }

    public void OnTriggerEnter(Collider col)
    {
        Debug.Log("Trigger! " + col.gameObject.tag);
        if (col.gameObject.tag == "Coin")
        {
            // Get the MinimapObject component attached to the coin
            MinimapObject minimapObject = col.GetComponent<MinimapObject>();
            coins = coins + 1;

            // Check if the MinimapObject component exists
            if (minimapObject != null)
            {
                // Mark the coin as destroyed
                minimapObject.DestroyObject();
            }

            // Destroy the coin game object
            col.gameObject.SetActive(false);

            if (coins >= coinVictoryAmount)
            {
                coins = 0;
                victoryMenu.SetActive(true);
            }
        }
        else if (col.gameObject.tag == "Guard")
        {
            Debug.Log("Busted!");
            coins = 0;
            loseMenu.SetActive(true);
        }

        UpdateText();
    }

    private void UpdateText() {
        coinText.text = "Collected Coins: " + coins.ToString() + "/" + coinVictoryAmount.ToString();
    }
}
