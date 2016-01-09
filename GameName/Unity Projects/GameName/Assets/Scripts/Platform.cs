using UnityEngine;

public abstract class Platform {

    /// <summary>
    /// Will check to see if the Player has moved
    /// </summary>
    /// <returns>Vector3 with cords if Player has moved, else Vector3.zero</returns>
    public abstract Vector3 CheckPlayerMovement();

    /// <summary>
    /// Will check to see if the Player has Jumped
    /// </summary>
    /// <returns>bool - True if Player Jumped</returns>
    public abstract bool CheckPlayerJump();
}
