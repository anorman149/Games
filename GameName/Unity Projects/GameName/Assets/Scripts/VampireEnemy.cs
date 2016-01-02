public class VampireEnemy : Enemy {
    protected override void Start() {
        health = 150;
        damage = 20;
        speed = 1.5f;
        jumpSpeed = 60;
        coinsToTakeAway = 20;

        base.Start();
    }
}
