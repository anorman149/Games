using System.Collections;
using UnityEngine;

public class MovementController : MonoBehaviour {

    /// <summary>
    /// Will move the Unit while checking for direction
    /// </summary>
    /// <param name="unit">Unit to Move</param>
    /// <param name="move">Vector3 Movement</param>
    public static void Move(Unit unit, Vector3 move) {
        //Move the unit
        unit.RigidBody.velocity = new Vector2(move.x * unit.Speed, unit.RigidBody.velocity.y);

        //If the unit moved direction
        if (move.x > 0 && !unit.FacingRight) {
            Flip(unit);
        } else if(move.x < 0 && unit.FacingRight) {
            Flip(unit);
        }

        //Character Animation for Move
        unit.Animate(Animation.Walk, Mathf.Abs(move.x));
    }

    /// <summary>
    /// Will make the Player Jump at their desired Velocity
    /// </summary>
    /// <param name="unit">Unit to Jump</param>
    public static void Jump(Unit unit) {
        unit.RigidBody.AddForce(new Vector2(0, unit.JumpVelocity));
    }

    /// <summary>
    /// Will change the direction of the Unit
    /// </summary>
    private static void Flip(Unit unit) {
        unit.FacingRight = !unit.FacingRight;
        Vector3 theScale = unit.transform.localScale;
        theScale.x *= -1;
        unit.transform.localScale = theScale;
    }

    /// <summary>
    /// Will clamp the Unit to the screen
    /// </summary>
    /// <param name="unit">Unit to Clamp</param>
    public static void ClampUnit(Unit unit) {
        //Clamp the position of the player into the boundaries
        float maxWidth = GameManager.instance.maxWidth - unit.Collider.bounds.extents.x;
        unit.transform.position = (new Vector2(Mathf.Clamp(unit.transform.position.x, -maxWidth, maxWidth), unit.transform.position.y));
    }

    /// <summary>
    /// Will Knock the Unit back
    /// </summary>
    /// <param name="duration">Duration of KnockBack</param>
    /// <param name="knockBackPower">Power of the KnockBack</param>
    /// <param name="unit">Unit to Knockback</param>
    /// <returns></returns>
    public static IEnumerator KnockBack(float duration, float knockBackPower, Unit unit) {
        float timer = 0;

        while(duration > timer) {
            timer += Time.deltaTime;

            float moveX = unit.FacingRight ? -knockBackPower : knockBackPower;

            unit.RigidBody.velocity = new Vector2(moveX, 0);

            //Make sure they are still clamped
            ClampUnit(unit);
        }

        yield return 0;
    }

    /// <summary>
    /// Will check the distance between Units
    /// </summary>
    /// <param name="a">Unit to check with</param>
    /// <param name="b">Unit to check against</param>
    /// <returns></returns>
    public static float CheckDistanceFromUnit(Unit a, Unit b) {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }
}
