using System;
using UnityEngine;

public class Enemy : Unit {

    private Player player;

    protected int coinsToTakeAway;
    private bool spawning;
    private float maxDistanceToPlayer = 2f;
    private float distanceFromPlayer;
    private float attackWaitTime = 1f;
    private float knockBackPower = 6f;

    protected virtual void Start () {
        Animator = GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
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

        //Check to see if the Unit is Dead
        if(Dead) {
            disable();
        }

        //Check for Distance
        if(!player.IsDead()) {
            distanceFromPlayer = MovementController.CheckDistanceFromUnit(this, player);
        }

        MoveEnemy();
    }

    /// <summary>
    /// Will control the enemies
    /// </summary>
    public void MoveEnemy() {
        //Only need to move if the distance is within it's max and Player is not Dead
        if((!player.IsDead() && player.enabled) && distanceFromPlayer > maxDistanceToPlayer) {
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

                //Subtract the necessary amount of coins
                GUIManager.instance.SubtractCoins(coinsToTakeAway);
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

        //Need to show Damage Taken Text
        FloatingText.Show(Convert.ToString(damage), GUIUtils.getDamageText(), new FromWorldPointTextPositioner(transform.position, 1f, 50));

        //TODO sounds or something here

        //Need to check and see if the Enemy died
        CheckHealth();
    }

    /// <summary>
    /// Check if the Enemy has died
    /// </summary>
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

        //Stop the Movement
        MovementController.StopMovement(this);

        //Wait until the Animation has finished
        StartCoroutine(UnitController.WaitForSeconds(Animator.GetCurrentAnimatorStateInfo(0).length, this));

        //TODO add Sound and more things to do before dying
    }

    /// <summary>
    /// Will Disable and Destroy the Unit
    /// </summary>
    private void disable() {
        Destroy(this.gameObject);
        GetComponent<Renderer>().enabled = false;
    }

    public override void OnTriggerEnter2D(Collider2D collider) {
        //TODO add collision to things
    }

    public override void OnCollisionEnter2D(Collision2D collision) {
        //Check to see if we ran into the Player
        if(collision.gameObject.tag.Equals("Player")) {
            DealDamage(collision.gameObject);

            //Distance between the Enemey and the Player
            Vector3 move = player.transform.position - transform.position;
            move.Normalize();

            //Knock the Player back a little
            StartCoroutine(MovementController.KnockBack(0.02f, knockBackPower, player, move.x));

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
