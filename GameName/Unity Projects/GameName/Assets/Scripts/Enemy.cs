using UnityEngine;

public class Enemy : Unit {

    protected Animator animator;
    private Transform target;

    protected int coinsToTakeAway;
    protected int enemiesToSpawn;
    protected int enemySpawnFreq;

    protected override void Start () {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        base.Start();
	}

    /// <summary>
    /// Unit to Attack
    /// </summary>
    /// <param name="obj">Which Object the Unit will do damage to</param>
    public override void DealDamage(object obj) {
        //Check to see if the Object is a Player
        if (obj is Player) {
            Player player = obj as Player;

            //Let's do some damage and take away coins
            player.TakeDamage(damage);
            player.LoseCoins(coinsToTakeAway);
        }
    }

    /// <summary>
    /// Damage the Enemy
    /// </summary>
    /// <param name="damage">Amount of Damage to Enemy</param>
    public override void TakeDamage(int damage) {
        health -= damage;

        //Play Animation for taking damage
        animator.SetTrigger("Damage");

        //Need to check and see if the Enemy died
        CheckDeath();
    }

    /// <summary>
    /// Will control the enemies
    /// </summary>
    public void MoveEnemy() {
        int horizontal = (int)Input.GetAxisRaw("Horizontal");
        int vertical = (int)Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);

        //TODO Add Enemy Movemnt commands here
    }

    //Need to check if the Enemy has died
    public override void CheckDeath() {
        if (health <= 0) {
            //Play death animation
            animator.SetTrigger("Die");

            //TODO add more things to do before dying

            enabled = false;
        }
    }

    public override void OnTriggerEnter2D(Collider2D collider) {
        //TODO add collision to things
    }

    /// <summary>
    /// Will Animate the Enemie's Walking
    /// </summary>
    protected override void Animate() {
        animator.SetFloat("Speed", Mathf.Abs(move.x));
    }
}
