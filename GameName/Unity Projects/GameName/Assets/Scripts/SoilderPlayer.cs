public class SoilderPlayer : Player {
    protected override void Start() {
        Health = 100;
        Damage = 50;
        Speed = 4;
        JumpVelocity = 90;
        WeaponRange = 8f;

        base.Start();
    }
}
