using System;
using UnityEngine;

public class Player : Unit {
    public float WeaponRange;

    // Use this for initialization
    protected virtual void Start () {
        Animator = GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
        RigidBody = GetComponent<Rigidbody2D>();

        IsGrounded = true;
        FacingRight = true;
	}

	public override void FixedUpdate() {
        base.FixedUpdate();

        //Check to see if the Unit needs to wait
        if(wait) {
            return;
        }

        //Check to see if it's Game Over
        if(GameManager.instance.playerLives <= 0) {
            disable();
        }

        if(Dead && GameManager.instance.playerLives > 0) {
            //Will need to Respawn
            PlayerRespawn.Instantiate();

            //Destroy the current Player
            Destroy(gameObject);
        }

        //TODO Add audio or something here

        //Check if Player moved
        Move();
    }

    void Update() {
        //See if we are jumping
        if (GameManager.instance.platform.CheckJump() && IsGrounded) {
            //Set the animation
            Animate(Animation.Ground, false);

            MovementController.Jump(this);
        }

        //See if they are off the ground. They can 
        //push DOWN and fall faster
        if(!IsGrounded && GameManager.instance.platform.CheckDown()) {
            MovementController.FallFaster(this);
        }
    }

    /// <summary>
    /// Will move the Player if the input was detected
    /// </summary>
    private void Move() {
        //Check if Player moved
        Vector3 move = GameManager.instance.platform.CheckPlayerMovement();

        //Only update for moving if we actually moved
        if(!move.Equals(Vector3.zero)) {
            MovementController.Move(this, move);
        }
    }

    /// <summary>
    /// Damage the Player
    /// </summary>
    /// <param name="damage">Amount of Damage to Player</param>
    public override void TakeDamage(int damage) {
        CurrentHealth -= damage;

        //Play Animation for taking damage
        Animate(Animation.Damage, "");

        //Need to show Damage Taken Text
        FloatingText.Show(string.Format("-{0}", Convert.ToString(damage)), GUIUtils.getDamageText(), new FromWorldPointTextPositioner(transform.position, 2f, 50));

        //Need to check and see if we died
        CheckHealth();
    }

    /// <summary>
    /// Will subtract a Life, call Death, and start back at MaxHealth. 
    /// </summary>
    public void SubtractLife() {
        Death();

        if(GameManager.instance.playerLives > 0) {
            GameManager.instance.playerLives -= 1;
            CurrentHealth = MaxHealth;
        }
    }

    /// <summary>
    /// Will add the supplied health to the health total
    /// </summary>
    /// <param name="amountOfHealth">Amount of health to add</param>
    public void AddHealth(int amountOfHealth) {
        CurrentHealth += amountOfHealth;

        //Can't go over 100, so set it back
        if(CurrentHealth > 100) {
            CurrentHealth = 100;
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
        StartCoroutine(UnitController.WaitForSeconds(Animator.GetCurrentAnimatorStateInfo(0).length + .6f, this));

        //TODO Add sound
    }

    /// <summary>
    /// Will Disable and Destroy the Unit
    /// </summary>
    private void disable() {
        enabled = false;
        Destroy(this.gameObject);

        //The game has ended if no lives
        GameManager.instance.GameOver();
    }

    /// <summary>
    /// Check whether the Player has Died
    /// If the Player has no more lives, it will end the game
    /// If another life exists, it will use it
    /// </summary>
    public override void CheckHealth() {
        if (CurrentHealth <= 0) {
            //TODO add Sound
            //TODO add Animation for using Life
            SubtractLife();
        }
    }

    /// <summary>
    /// Unit to Attack
    /// </summary>
    /// <param name="obj">Which Object the Unit will do damage to</param>
    public override void DealDamage(GameObject gameObject) {
        //Check to see if the Object is an Enemy AND if the Enemy is in Range of the Player's weapon
        if(gameObject.tag.Equals("Enemy") && MovementController.CheckDistanceFromUnit(this, gameObject.GetComponent<Enemy>()) <= WeaponRange) {
            Enemy enemy = gameObject.GetComponent<Enemy>();

            //Let's check current animation, if the Player is already attacking, we don't want to again
            bool attacking = Animator.GetCurrentAnimatorStateInfo(0).IsName(Animation.Attack.ToString()) && !Animator.IsInTransition(0);

            //If not Dead AND the Player is facing the same direction, then do some damage
            if(!enemy.IsDead() && UnitController.UnitsFacingEachOther(this, enemy) && !attacking) {
                //Play Animation for taking damage
                Animate(Animation.Attack, "");

                enemy.TakeDamage(Damage);
            }
        }
    }

    public override void OnTriggerEnter2D(Collider2D collider) {
        GameObject colliderGameObject = collider.gameObject;

        if(colliderGameObject.tag.Equals("Item")) {
            //The Player has collided with an Item
            IItem item = colliderGameObject.GetComponent(colliderGameObject.name) as IItem;

            //Pickup the Item
            item.PickupAction(this.gameObject);

            //Disable the Item now, since it was picked up
            item.DisableOnPickup();
        }

        //TODO Need to figure out Exits
    }

    /// <summary>
    /// Will disable the Player and End the Level
    /// </summary>
    public void FinishLevel() {
        enabled = false;

        //TODO add more code for finishing level
    }

    public override void OnCollisionEnter2D(Collision2D collision) {
        //Leave blank for now. Only add if something needs to be done when
        //Player Collides with something
    }
}
