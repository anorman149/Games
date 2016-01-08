public class SoilderPlayer : Player {
    protected override void Start() {
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        Damage = 50;
        Speed = 4;
        JumpVelocity = 90;
        WeaponRange = 8f;

        base.Start();
    }
}
