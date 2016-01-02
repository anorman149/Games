using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public int playerCoins;
    public int playerLives;

    public Camera cam;
    public float maxWidth;

    void Awake () {
	    if(instance == null) {
            instance = this;
        } else if(instance != null) {
            Destroy(gameObject);
        }

        if (cam == null) {
            cam = Camera.main;
        }

        //Need to grab the Width of the Scene
        Vector3 uppercorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(uppercorner);
        maxWidth = targetWidth.x;

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
