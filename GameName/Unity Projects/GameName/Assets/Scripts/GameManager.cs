using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public int playerCoins = 0;
    public int playerLives = 3;
    public Platform platform;
    public Player WhichPlayerChosen;

    [HideInInspector]
    public float maxWidth;
    [HideInInspector]
    public bool gameOver = false;

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
        //Setup Platform
        if(platform == null) {
            platform = PlatformFactory.GetPlatform();
        }

        //Need to grab the Width of the Scene
        Vector3 uppercorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = Camera.main.ScreenToWorldPoint(uppercorner);
        maxWidth = targetWidth.x;
    }

    void Update() {
        //If the Player doens't exist, go grab it
        if(WhichPlayerChosen == null) {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            if(playerObject != null) {
                WhichPlayerChosen = playerObject.GetComponent<Player>();
            }
        }
    }

    /// <summary>
    /// Will End the Game
    /// </summary>
    public void GameOver() {
        //Grab the Animator from the Canvas and Trigger the Game Over
        AnimationMethods.setAnimationTypeAndValue(Animation.GameOver, GameObject.Find("HUDCanvas").GetComponent<Animator>(), "");

        //TODO Add Continue??
        gameOver = true;
        gameObject.AddComponent<GameOver>();
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
        GUIManager.instance.UpdateCoins();
    }

    /// <summary>
    /// Will add the supplied Coins
    /// </summary>
    /// <param name="coinsToAdd">Amount of coins to add</param>
    public void AddCoins(int coinsToAdd) {
        playerCoins += coinsToAdd;

        //Update the Screen
        GUIManager.instance.UpdateCoins();
    }

    /// <summary>
    /// Will Reset Player's Lives and Player's Coins
    /// </summary>
    public void Reset() {
        playerCoins = 0;
        playerLives = 3;
        gameOver = false;
    }
}