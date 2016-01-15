using UnityEngine;

public class Loader : MonoBehaviour {

    public GameObject gameManager;
    public GameObject levelManager;
    public GameObject guiManager;

	// Use this for initialization
	void Awake () {
        if (gameManager != null && GameManager.instance == null) {
            Instantiate(gameManager);
        }

        if(levelManager != null && LevelManager.instance == null) {
            Instantiate(levelManager);
        }

        if(guiManager != null && GUIManager.instance == null) {
            Instantiate(guiManager);
        }
	}
}
