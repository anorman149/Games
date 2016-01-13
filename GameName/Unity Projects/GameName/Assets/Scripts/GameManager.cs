using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public int playerCoins = 0;
    public int playerLives = 3;
    public Platform platform;
    public Text coinText;

    [HideInInspector]
    public Camera cam;
    [HideInInspector]
    public float maxWidth;

    void Awake () {
	    if(instance == null) {
            instance = this;
        } else if(instance != null) {
            Destroy(gameObject);
        }

        //Setup Camera
        if(cam == null) {
            cam = Camera.main;
        }

        //Setup Platform
        if (platform == null) {
            platform = PlatformFactory.GetPlatform();
        }

        //Show the Coins on Screen
        UpdateCoins();

        //Need to grab the Width of the Scene
        Vector3 uppercorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(uppercorner);
        maxWidth = targetWidth.x;

        //So the Application doesn't destroy this Object
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Will End the Game
    /// </summary>
    public void GameOver() {
        //Grab the Animator from the Canvas and Trigger the Game Over
        AnimationMethods.setAnimationTypeAndValue(Animation.GameOver, GameObject.Find("HUDCanvas").GetComponent<Animator>(), "");

        //TODO Add Continue??
        gameObject.AddComponent<GameOver>().gameOver = true;
    }

    /// <summary>
    /// Will update the coins on the screen
    /// </summary>
    private void UpdateCoins() {
        coinText.text = Convert.ToString(playerCoins);
    }

    /// <summary>
    /// Will subtract coins
    /// </summary>
    /// <param name="coinsLost">Amount of coins to lose</param>
    public void SubtractCoins(int coinsLost) {
        playerCoins -= coinsLost;

        //If coins are now below 0, let's set to 0
        if(playerCoins < 0) {
            playerCoins = 0;
        }

        //Update the Screen
        UpdateCoins();
    }

    /// <summary>
    /// Will add the supplied Coins
    /// </summary>
    /// <param name="coinsToAdd">Amount of coins to add</param>
    public void AddCoins(int coinsToAdd) {
        playerCoins += coinsToAdd;

        //Update the Screen
        UpdateCoins();
    }

    public void Reset() {
        playerCoins = 0;
        playerLives = 3;
    }
}