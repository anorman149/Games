public class ZombieEnemy : Enemy {
    protected override void Start() {
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        Damage = 10;
        Speed = 3f;
        JumpVelocity = 60;
        coinsToTakeAway = 10;

        base.Start();
    }
}
