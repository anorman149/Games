using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance = null;
    public int level;

    // Use this for initialization
    void Start () {
        if (instance == null) {
            instance = this;
        } else if (instance != null) {
            Destroy(gameObject);
        }

        level = 0;

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update () {
	
	}

    /// <summary>
    /// This will be called each time a scene is loaded.
    /// </summary>
    void OnLevelWasLoaded(int index) {
        level++;
    }
}
