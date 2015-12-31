using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    public int playerCoins;
    public int level;
    public int playerLives;

	void Awake () {
	    if(instance == null) {
            instance = this;
        } else if(instance != null) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
	}

    public void GameOver() {
        enabled = false;
    }
}
