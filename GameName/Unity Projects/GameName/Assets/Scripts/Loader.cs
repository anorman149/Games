using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameManager;
    public GameObject levelManager;

	// Use this for initialization
	void Awake () {
        if (GameManager.instance == null) {
            Instantiate(gameManager);
        }

        if(LevelManager.instance == null) {
            Instantiate(levelManager);
        }
	}
}
