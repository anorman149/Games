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

    public override bool CheckHorizontal() {
        if(Input.GetAxis("Horizontal") != 0) {
            return true;
        }

        return false;
    }

    public override bool CheckVertical() {
        if(Input.GetAxis("Vertical") != 0) {
            return true;
        }

        return false;
    }

    public override bool CheckJump() {
        if(Input.GetKey(KeyCode.Space)) {
            return true;
        }

        return false;
    }

    public override bool CheckClick() {
        return Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1);
    }

    public override bool CheckTouch() {
        //No Touch on Windows
        return false;
    }

    public override bool CheckDown() {
        return Input.GetAxis("Vertical") < 0;
    }
}
