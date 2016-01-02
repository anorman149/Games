public class BlackSoilderPlayer : Player {
    protected override void Start() {
        health = 100;
        damage = 50;
        speed = 3;
        jumpSpeed = 60;

        base.Start();
    }
}
