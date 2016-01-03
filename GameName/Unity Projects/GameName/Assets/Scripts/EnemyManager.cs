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
        // Don't spawn if dead
        if(player.IsDead()) {
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
