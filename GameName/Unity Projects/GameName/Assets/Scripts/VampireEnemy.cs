public class VampireEnemy : Enemy {
    protected override void Start() {
        MaxHealth = 150;
        CurrentHealth = MaxHealth;
        Damage = 20;
        Speed = 3f;
        JumpVelocity = 60;
        coinsToTakeAway = 20;

        base.Start();
    }
}
