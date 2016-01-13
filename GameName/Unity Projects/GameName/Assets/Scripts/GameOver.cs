using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public bool gameOver = false;

	void Update () {
        //If the User Clicks, then go to the Start Screen
        if(gameOver && (GameManager.instance.platform.CheckClick() || GameManager.instance.platform.CheckTouch())) {
            SceneManager.LoadScene("StartScreen");
        }
	}
}
