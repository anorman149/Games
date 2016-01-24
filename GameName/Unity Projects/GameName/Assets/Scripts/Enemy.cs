using System;
using UnityEngine;

public class Enemy : Unit {

    private Player player;

    protected int coinsToTakeAway;
    protected bool spawning;
    protected float maxDistanceToPlayer;
    protected float distanceFromPlayer;
    protected float attackWaitTime;

    protected virtual void Start () {
        Animator = GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
        RigidBody = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public override void FixedUpdate() {
        base.FixedUpdate();

        //Let's try resetting the Player (will be here for when the Player Dies)
        if(player == null) {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if(playerObject != null) {
                player = playerObject.GetComponent<Player>();
            }
        }

        //Need to account for Spawning
        spawning = CheckCurrentAnimationPlaying(Animation.Appear);
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

        //Check if Unit moved
        Move();

        //Check if Unit Attacked
        Attack();
    }

    /// <summary>
    /// Will control the enemies
    /// </summary>
    public void Move() {
        //Let's check current animation, if the Enemy is hurt, let's not move
        bool hurt = CheckCurrentAnimationPlaying(Animation.Damage);

        //Only need to move if the distance is within it's max and Player is not Dead
        if(!player.IsDead() && !hurt && distanceFromPlayer > maxDistanceToPlayer) {
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
    /// Damage the Enemy
    /// </summary>
    /// <param name="damage">Amount of Damage to Enemy</param>
    public override void ReceiveDamage(float damage) {
        CurrentHealth -= damage;

        //Play Animation for taking damage
        Animate(Animation.Damage, "");

        //Need to show Damage Taken Text
        FloatingText.Show(string.Format("-{0}", Convert.ToString(damage)), GUIUtils.damageStyle, new FromWorldPointTextPositioner(transform.position, 1f, 50));

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
        Collider.enabled = false;

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
}
