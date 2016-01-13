using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance = null;

    // Use this for initialization
    void Start () {
        if (instance == null) {
            instance = this;
        } else if (instance != null) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void GoToNextLevel(string levelName) {
        StartCoroutine(GoToNextLevelCo(levelName));
    }

    private IEnumerator GoToNextLevelCo(string levelName) {
        //Allow the Player to Finish the Level
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().FinishLevel();

        //Show Level Complete Text
        FloatingText.Show("Level Complete!", GUIUtils.getEndLevelText(), new CenteredTextPositioner(.2f));

        //Wait 1 Second
        yield return new WaitForSeconds(1);

        //Show the Total Coins for the Player
        FloatingText.Show(string.Format("{0} coins!", GameManager.instance.playerCoins), GUIUtils.getEndLevelText(), new CenteredTextPositioner(.1f));

        //Wait 5 Seconds to switch to new Level
        yield return new WaitForSeconds(5f);

        //Load the Start Screen if there is No Level Attached
        if(string.IsNullOrEmpty(levelName)) {
            SceneManager.LoadScene("StartScreen");
        } else {
            SceneManager.LoadScene(levelName);
        }
    }
}
