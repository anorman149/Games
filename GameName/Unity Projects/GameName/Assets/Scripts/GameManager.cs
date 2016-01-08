using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public int playerCoins;
    public int playerLives;

    public float maxWidth;

    public Platform platform;

    void Awake () {
	    if(instance == null) {
            instance = this;
        } else if(instance != null) {
            Destroy(gameObject);
        }

        //Setup Platform
        if (platform == null) {
            platform = PlatformFactory.GetPlatform();
        }

        playerCoins = 0;
        playerLives = 3;

        //Need to grab the Width of the Scene
        Vector3 uppercorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = GetComponent<Camera>().ScreenToWorldPoint(uppercorner);
        maxWidth = targetWidth.x;

        //So the Application doesn't destroy this Object
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Will End the Game
    /// </summary>
    public void GameOver() {
        //TODO Add things to do before end of Game

        enabled = false;
    }
}
