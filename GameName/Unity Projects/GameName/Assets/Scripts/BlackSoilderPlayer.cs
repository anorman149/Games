public class BlackSoilderPlayer : Player {
    protected override void Start() {
        health = 100;
        damage = 50;

        base.Start();
    }

    public override void TakeDamage(int damage) {
        //Play Animation for taking damage
        animator.SetTrigger("playerTakeDamage");

        base.TakeDamage(damage);
    }
}
