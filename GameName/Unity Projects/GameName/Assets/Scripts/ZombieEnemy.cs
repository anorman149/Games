public class ZombieEnemy : Enemy {
    protected override void Start() {
        health = 100;
        damage = 10;
        speed = 1f;
        jumpSpeed = 60;
        coinsToTakeAway = 10;

        base.Start();
    }
}
