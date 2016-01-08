using UnityEngine;

public interface IItem {

    /// <summary>
    /// The Item
    /// </summary>
    /// <returns>Item - Will return the Item</returns>
    IItem GetItem();

    /// <summary>
    /// The animation upon Pickup
    /// </summary>
    void AnimateOnPickup();

    /// <summary>
    /// The Value of the Item
    /// </summary>
    /// <returns>int - Value of Item</returns>
    int GetValue();

    /// <summary>
    /// Will Disable the Item since it was picked up
    /// </summary>
    void DisableOnPickup();

    /// <summary>
    /// Will be the Action that happens when the object is Pickedup
    /// </summary>
    /// <param name="gameObject">The Game Object that Collided with the Item</param>
    void PickupAction(GameObject gameObject);
}
