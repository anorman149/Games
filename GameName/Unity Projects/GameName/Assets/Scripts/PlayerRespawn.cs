using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {

    public IEnumerator Start() {
        //The Spawn Point
        Transform spawnPoint = GameObject.Find("PlayerSpawnPoint").transform;

        //Grab the Player Prefab
        Player player = Resources.Load("Prefabs/units/Player", typeof(Player)) as Player;

        //Let's wait some time before Re-Spawning
        yield return new WaitForSeconds(.5f);

        // Create an instance of the player prefab at the spawn point's position and rotation.
        Instantiate(player, spawnPoint.position, spawnPoint.rotation);
    }

    /// <summary>
    /// Will Instantiate a New Player Game Object
    /// </summary>
    public static void Instantiate() {
        GameObject go = new GameObject("PlayerRespawn");

        //Will create a Game Obejct and place this Script on it
        go.AddComponent<PlayerRespawn>();
    }
}
