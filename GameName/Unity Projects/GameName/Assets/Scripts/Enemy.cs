using UnityEngine;

public class Enemy : Unit {

    private Player player;

    protected int coinsToTakeAway;
    private bool spawning;
    private float maxDistanceToPlayer = 2f;
    private float distanceFromPlayer;
    private float attackWaitTime = 1f;

    protected virtual void Start () {
        Animator = GetComponent<Animator>();
        Collider = GetComponent<PolygonCollider2D>();
        RigidBody = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public override void FixedUpdate() {
        base.FixedUpdate();

        //Need to account for Spawning
        spawning = Animator.GetCurrentAnimatorStateInfo(0).IsName("Appear") && !Animator.IsInTransition(0);
        if(spawning) {
            return;
        }

        //Check to see if the Unit needs to wait
        if(wait) {
            return;
        }

        //Check for Distance
        distanceFromPlayer = MovementController.CheckDistanceFromUnit(this, player);

        MoveEnemy();
    }

    /// <summary>
    /// Will control the enemies
    /// </summary>
    public void MoveEnemy() {
        //Only need to move if the distance is within it's max and Player is not Dead
        if(!player.IsDead() && distanceFromPlayer > maxDistanceToPlayer) {
            //Distance between the Enemey and the Player
            Vector3 move = player.transform.position - transform.position;
            move.Normalize();
            
            MovementController.Move(this, move);

            //TODO Add sound or something
        } else {
            //Turn animation off
            Animate(Animation.Walk, 0f);
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

            //We should probably only do damage if the Player is NOT Dead
            if(!player.IsDead()) {
                //Play Animation for taking damage
                Animate(Animation.Attack, "");

                //Let's do some damage and take away coins
                player.TakeDamage(Damage);
                player.SubtractCoins(coinsToTakeAway);
            }
        }
    }

    /// <summary>
    /// Damage the Enemy
    /// </summary>
    /// <param name="damage">Amount of Damage to Enemy</param>
    public override void TakeDamage(int damage) {
        CurrentHealth -= damage;

        //Play Animation for taking damage
        Animate(Animation.Damage, "");

        //TODO sounds or something here

        //Need to check and see if the Enemy died
        CheckHealth();
    }

    //Need to check if the Enemy has died
    public override void CheckHealth() {
        if (CurrentHealth <= 0) {
            Death();
        }
    }

    /// <summary>
    /// Will kill the Unit
    /// </summary>
    public override void Death() {
        //Play death animation
        Dead = true;
        Animate(Animation.Dead, Dead);

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

            //Stop the enemy from moving for a little
            StartCoroutine(UnitController.WaitForSeconds(attackWaitTime, this));
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
