public class BlackSoilderPlayer : Player {
    protected override void Start() {
        Health = 100;
        Damage = 50;
        Speed = 3;
        JumpSpeed = 60;

        base.Start();
    }
}
