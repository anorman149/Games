using UnityEngine;

public class Windows : Platform {
    public override Vector3 CheckPlayerMovement() {
        Vector3 move = Vector3.zero;

        //Grab locations and set
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Only set if Player moved
        if(horizontal != 0) {
            move = new Vector3(horizontal, 0f, vertical);
        }

        return move;
    }

    public override bool CheckPlayerJump(Unit unit) {
        if(Input.GetKey(KeyCode.Space) && unit.IsGrounded) {
            return true;
        }

        return false;
    }
}
