using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        //Check to see if the Mouse Button has been pressed or Touch has happened
        if(GameManager.instance.platform.CheckClick() || GameManager.instance.platform.CheckTouch()) {
            //Need to Rest GameManager
            GameManager.instance.Reset();

            //Will Load the First Level
            SceneManager.LoadScene("Level1");
        }
	}
}
