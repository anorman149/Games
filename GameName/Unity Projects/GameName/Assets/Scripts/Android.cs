using UnityEngine;
using System;

public class Android : Platform {
    public override Vector3 CheckPlayerMovement() {
        throw new NotImplementedException();
    }

    public override bool CheckPlayerJump(Unit unit) {
        throw new NotImplementedException();
    }
}
