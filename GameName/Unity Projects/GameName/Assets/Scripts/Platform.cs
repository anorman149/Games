﻿using UnityEngine;

public abstract class Platform {

    /// <summary>
    /// Will check to see if the Player has moved
    /// </summary>
    /// <returns>Vector3 with cords if Player has moved, else Vector3.zero</returns>
    public abstract Vector3 CheckPlayerMovement();

    /// <summary>
    /// Will check to see if Moving sideways has been issued
    /// </summary>
    /// <returns>True if so</returns>
    public abstract bool CheckHorizontal();

    /// <summary>
    /// Will check to see if Moving Up has been issued
    /// </summary>
    /// <returns>True if so</returns>
    public abstract bool CheckVertical();

    /// <summary>
    /// Will check to see if Jump has been issued
    /// </summary>
    /// <returns>True if so</returns>
    public abstract bool CheckJump();
}
