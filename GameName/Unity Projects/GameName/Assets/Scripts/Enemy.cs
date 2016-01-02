using UnityEngine;

public class Enemy : Unit {

    private Transform target;

    protected int coinsToTakeAway;
    protected int enemiesToSpawn;
    protected int enemySpawnFreq;

    protected virtual void Start () {
        Animator = GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
        RigidBody = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
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
            player.TakeDamage(Damage);
            player.LoseCoins(coinsToTakeAway);
        }
    }

    /// <summary>
    /// Damage the Enemy
    /// </summary>
    /// <param name="damage">Amount of Damage to Enemy</param>
    public override void TakeDamage(int damage) {
        Health -= damage;

        //Play Animation for taking damage
        Animate(Animation.Damage, "");

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
        if (Health <= 0) {
            //Play death animation
            Animate(Animation.Die, "");

            //TODO add more things to do before dying

            enabled = false;
        }
    }

    public override void OnTriggerEnter2D(Collider2D collider) {
        //TODO add collision to things
    }
}
