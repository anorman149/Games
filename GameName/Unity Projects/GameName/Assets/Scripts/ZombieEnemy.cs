public class ZombieEnemy : Enemy {
    protected override void Start() {
        Health = 100;
        Damage = 10;
        Speed = 3f;
        JumpVelocity = 60;
        coinsToTakeAway = 10;

        base.Start();
    }
}
