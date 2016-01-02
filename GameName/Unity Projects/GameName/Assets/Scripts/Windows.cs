using UnityEngine;

public class Windows : Platform {

    public override void Move(Unit unit, Vector3 move) {
        //Move the unit
        unit.RigidBody.velocity = new Vector2(move.x * unit.Speed, unit.RigidBody.velocity.y);

        //Clamp the position of the player into the boundaries
        float maxWidth = GameManager.instance.maxWidth - unit.Collider.bounds.extents.x;
        unit.transform.position = (new Vector2(Mathf.Clamp(unit.transform.position.x, -maxWidth, maxWidth), unit.transform.position.y));
    }
}
