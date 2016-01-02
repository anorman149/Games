public class VampireEnemy : Enemy {
    protected override void Start() {
        Health = 150;
        Damage = 20;
        Speed = 1.5f;
        JumpSpeed = 60;
        coinsToTakeAway = 20;

        base.Start();
    }
}
