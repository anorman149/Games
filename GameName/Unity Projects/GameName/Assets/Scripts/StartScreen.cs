using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        //Check to see if the Mouse Button has been pressed
        //TODO Change this to the Platform
        if(!Input.GetMouseButtonDown(0)) {
            return;
        }

        //Will Load the First Level
        SceneManager.LoadScene("Level1");
	}
}
