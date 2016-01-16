using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public int playerCoins = 0;
    public int playerLives = 3;
    public Platform platform;

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
    /// Will Reset Player's Lives and Player's Coins
    /// </summary>
    public void Reset() {
        playerCoins = 0;
        playerLives = 3;
        gameOver = false;
    }
}