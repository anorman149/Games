using UnityEngine;

public class MovementController : MonoBehaviour {

    /// <summary>
    /// Will move the Unit while checking for direction
    /// </summary>
    /// <param name="unit">Unit to Move</param>
    /// <param name="move">Vector3 Movement</param>
    public static void Move(Unit unit, Vector3 move) {
        ////Move the unit
        GameManager.instance.platform.Move(unit, move);

        //If the unit moved direction
        if (move.x > 0 && !unit.FacingRight) {
            Flip(unit);
        } else if(move.x < 0 && unit.FacingRight) {
            Flip(unit);
        }

        //Character Animation for Move
        unit.Animate(Animation.Walk, move.x);
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
}
