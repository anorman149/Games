using System.Collections;
using UnityEngine;

public class UnitController : MonoBehaviour {

    private static float groundRadius = 0.2f;

    /// <summary>
    /// Check to see if Unit is on Gound
    /// </summary>
    /// <param name="unit">The Unit in question</param>
    public static void UnitOnGround(Unit unit) {
        //Check whether we are on the ground or not
        unit.IsGrounded = Physics2D.OverlapCircle(unit.GroundCheck.position, groundRadius, unit.TheGround);
        unit.Animator.SetBool("Ground", unit.IsGrounded);
    }

    /// <summary>
    /// Will wait for the supplied Seconds
    /// </summary>
    /// <param name="duration">Seconds to wait</param>
    /// <param name="unit">Unit to wait</param>
    public static IEnumerator WaitForSeconds(float duration, Unit unit) {
        unit.wait = true;
        yield return new WaitForSeconds(duration);
        unit.wait = false;
    }
}
