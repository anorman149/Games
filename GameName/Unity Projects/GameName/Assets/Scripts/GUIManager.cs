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

    void Update() {
        //Will need to check if the Coin Text is null
        if(coinText == null) {
            GameObject ifExists = GameObject.Find("CoinText");

            //Check to see if the Coin Text exists on the Level
            if(ifExists != null) {
                //if so, grab the Coin Text
                coinText = ifExists.GetComponent<Text>();
            }
            
            //Update the Screen with the Coins
            UpdateCoins();
        }
    }

    /// <summary>
    /// Will update the coins on the screen
    /// </summary>
    public void UpdateCoins() {
        coinText.text = Convert.ToString(GameManager.instance.playerCoins);
    }
}
