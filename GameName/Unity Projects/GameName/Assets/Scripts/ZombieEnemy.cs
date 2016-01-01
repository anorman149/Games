public class ZombieEnemy : Enemy {
    protected override void Start() {
        health = 100;
        damage = 10;
        coinsToTakeAway = 10;

        base.Start();
    }

    public override void TakeDamage(int damage) {
        //Play Animation for taking damage
        animator.SetTrigger("zombieTakeDamage");

        base.TakeDamage(damage);
    }

    protected override void onCantMove<T>(T component) {
        //Play Animation for taking damage
        animator.SetTrigger("zombieAttack");

        base.onCantMove(component);
    }
}
