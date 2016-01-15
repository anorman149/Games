using System;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public static GUIManager instance = null;
    public Text coinText;

    void Awake () {
        //So the Application doesn't destroy this Object
        DontDestroyOnLoad(gameObject);

        if(instance == null) {
            instance = this;
        } else if(instance != this) {
            Destroy(gameObject);
        }
    }

    void Start() {
        //Show the Coins on Screen
        UpdateCoins();
    }

    /// <summary>
    /// Will update the coins on the screen
    /// </summary>
    private void UpdateCoins() {
        coinText.text = Convert.ToString(GameManager.instance.playerCoins);
    }

    /// <summary>
    /// Will subtract coins
    /// </summary>
    /// <param name="coinsLost">Amount of coins to lose</param>
    public void SubtractCoins(int coinsLost) {
        GameManager.instance.playerCoins -= coinsLost;

        //If coins are now below 0, let's set to 0
        if(GameManager.instance.playerCoins < 0) {
            GameManager.instance.playerCoins = 0;
        }

        //Update the Screen
        UpdateCoins();
    }

    /// <summary>
    /// Will add the supplied Coins
    /// </summary>
    /// <param name="coinsToAdd">Amount of coins to add</param>
    public void AddCoins(int coinsToAdd) {
        GameManager.instance.playerCoins += coinsToAdd;

        //Update the Screen
        UpdateCoins();
    }
}
