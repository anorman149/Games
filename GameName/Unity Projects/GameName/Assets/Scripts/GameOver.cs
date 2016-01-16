using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
	void Update () {
        //If the User Clicks, then go to the Start Screen
        if(GameManager.instance.gameOver && (GameManager.instance.platform.CheckClick() || GameManager.instance.platform.CheckTouch())) {
            SceneManager.LoadScene("StartScreen");
        }
	}
}
