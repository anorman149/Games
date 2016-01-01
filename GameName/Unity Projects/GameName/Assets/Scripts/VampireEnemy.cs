public class VampireEnemy : Enemy {

    protected override void Start() {
        health = 150;
        damage = 20;
        coinsToTakeAway = 20;

        base.Start();
    }

    public override void TakeDamage(int damage) {
        //Play Animation for taking damage
        animator.SetTrigger("vampireTakeDamage");

        base.TakeDamage(damage);
    }

    protected override void onCantMove<T>(T component) {
        //Play Animation for taking damage
        animator.SetTrigger("vampireAttack");

        base.onCantMove(component);
    }
}
