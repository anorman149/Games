using UnityEngine;
using System.Collections;

public class Enemy : Unit {

    private Transform playerTransform;
    private GameObject targetPlayer;
    private Player player;

    protected int coinsToTakeAway;
    protected int enemiesToSpawn;
    protected int enemySpawnFreq;
    protected bool spawning;

    protected virtual void Start () {
        Animator = GetComponent<Animator>();
        Collider = GetComponent<PolygonCollider2D>();
        RigidBody = GetComponent<Rigidbody2D>();

        targetPlayer = GameObject.FindGameObjectWithTag("Player");
        player = targetPlayer.GetComponent<Player>();
        playerTransform = targetPlayer.transform;
    }

    public override void FixedUpdate() {
        base.FixedUpdate();

        //Need to account for Spwaning
        spawning = Animator.GetCurrentAnimatorStateInfo(0).IsName("Appear") && !Animator.IsInTransition(0);

        if(!IsDead() && !player.IsDead() && !spawning) {
            MoveEnemy();
        }
    }

    /// <summary>
    /// Will control the enemies
    /// </summary>
    public void MoveEnemy() {
        //Distance between the Enemey and the Player
        if(!IsDead() && !player.IsDead() && !spawning) {
            Vector3 move = playerTransform.position - transform.position;
            move.Normalize();

            MovementController.Move(this, move);

            //TODO Add sound or something
        }
    }

    /// <summary>
    /// Unit to Attack
    /// </summary>
    /// <param name="obj">Which Object the Unit will do damage to</param>
    public override void DealDamage(GameObject gameObject) {
        //Check to see if the Object is a Player
        if (gameObject.tag.Equals("Player")) {
            Player player = gameObject.GetComponent<Player>();

            //Play Animation for taking damage
            Animate(Animation.Attack, "");

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

        //TODO sounds or something here

        //Need to check and see if the Enemy died
        CheckHealth();
    }

    //Need to check if the Enemy has died
    public override void CheckHealth() {
        if (Health <= 0) {
            Death();
        }
    }

    /// <summary>
    /// Will kill the Unit
    /// </summary>
    public void Death() {
        //Play death animation
        Animate(Animation.Dead, true);

        //TODO add Sound and more things to do before dying

        //enabled = false;
        //renderer.enabled = false;
    }

    public override void OnTriggerEnter2D(Collider2D collider) {
        //TODO add collision to things
    }

    public override void OnCollisionEnter2D(Collision2D collision) {
        //Check to see if we ran into the Player
        if(collision.gameObject.tag.Equals("Player")) {
            DealDamage(collision.gameObject);
        }
    }

    /// <summary>
    /// Will detect if the Player has Clicked this Object
    /// 
    /// CAUTION - Only works with PC
    /// </summary>
    public void OnMouseOver() {
        if(Input.GetMouseButtonDown(1)) {
            //This means the Player has Right Clicked the Enemey
            //Let's do some damage
            player.DealDamage(this.gameObject);
        }
    }
}
