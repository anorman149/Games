using UnityEngine;

public class EnemyManager : MonoBehaviour {

    private Player player;       
    public GameObject enemy;                
    public float spawnTime = 3f;            
    public Transform[] spawnPoints;


    void Start() {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", 0, spawnTime);
    }

    void Spawn() {
        //Let's just return out if the Game is Over
        if(GameManager.instance.gameOver) {
            return;
        }

        //Check just in-case the Object changed (Player Died)
        if(player == null) {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //Check to see if a Unit is in the way
        bool objectThere = MovementController.OverlapWithAnotherObject(spawnPoints[spawnPointIndex].position, .5f);

        // Don't spawn if dead OR a Unit is there
        if(player.IsDead() || objectThere) {
            return;
        }

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
