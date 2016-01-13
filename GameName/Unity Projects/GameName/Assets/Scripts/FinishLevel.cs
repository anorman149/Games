using UnityEngine;

public class FinishLevel : MonoBehaviour {

    public string LevelName;
    
    public void OnTriggerEnter2D(Collider2D collider) {
        //Check to see if it was the Player
        if(collider.GetComponent<Player>() == null) {
            return;
        }

        LevelManager.instance.GoToNextLevel(LevelName);
    }

}
