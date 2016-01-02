using UnityEngine;

public abstract class Platform {

    /// <summary>
    /// Will get the Movement pattern of the Platform
    /// </summary>
    /// <param name="unit">The Unit to Move</param>
    /// <param name="move">The Vector to Move to</param>
    public abstract void Move(Unit unit, Vector3 move);
}
