using UnityEngine;

public class EnemyManager : MonoBehaviour {

    private Player player;       
    public GameObject enemy;                
    public float spawnTime = 3f;            
    public Transform[] spawnPoints;


    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", 0, spawnTime);
    }

    void Spawn() {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //Check to see if an Object is in the way
        bool objectThere = Physics2D.OverlapCircle(spawnPoints[spawnPointIndex].position, .5f);

        // Don't spawn if dead OR an Object is there
        if(player.IsDead() || objectThere) {
            return;
        }

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
