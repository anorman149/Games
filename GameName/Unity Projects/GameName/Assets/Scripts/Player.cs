using UnityEngine;

public class Player : Unit {
    private int coins;
    private int lives;

    // Use this for initialization
    protected virtual void Start () {
        Animator = GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
        RigidBody = GetComponent<Rigidbody2D>();

        //Setup default params
        coins = GameManager.instance.playerCoins;
        lives = GameManager.instance.playerLives;
        IsGrounded = true;
        FacingRight = true;
	}

    /// <summary>
    /// If the Player is disabled for some reason the 
    /// coins and lives will be transfered to Game Manager
    /// </summary>
    private void OnDisable() {
        GameManager.instance.playerCoins = coins;
        GameManager.instance.playerLives = lives;
    }

	void FixedUpdate() {
        //TODO Add audio or something here

        //Grab locations and set
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0f, vertical);

        //Check whether we are on the ground or not
        UnitController.UnitOnGround(this);

        //Only update for moving if we actually moved horizontally
        if (horizontal != 0) {
            MovementController.Move(this, move);
        }
    }

    void Update() {
        //See if we are jumping
        if (Input.GetKey(KeyCode.Space) && IsGrounded) {
            //Set the animation
            Animate(Animation.Ground, false);
            RigidBody.AddForce(new Vector2(0, JumpSpeed));
        }
    }

    /// <summary>
    /// Damage the Player
    /// </summary>
    /// <param name="damage">Amount of Damage to Player</param>
    public override void TakeDamage(int damage) {
        Health -= damage;

        //Play Animation for taking damage
        Animate(Animation.Damage, "");

        //Need to check and see if we died
        CheckDeath();
    }

    /// <summary>
    /// Check whether the Player has Died
    /// If the Player has no more lives, it will end the game
    /// If another life exists, it will use it
    /// </summary>
    public override void CheckDeath() {
        if (Health <= 0) {
            if (lives <= 0) {
                //TODO add Sound
                enabled = false;

                //The game has ended if no lives
                GameManager.instance.GameOver();
                return;
            }

            //TODO add Sound
            //TODO add Animation for using Life
            lives -= 1;           
        }
    }

    /// <summary>
    /// Unit to Attack
    /// </summary>
    /// <param name="obj">Which Object the Unit will do damage to</param>
    public override void DealDamage(object obj) {
        //Check to see if the Object is an Enemy
        if (obj is Enemy) {
            Enemy enemy = obj as Enemy;

            //Let's do some damage
            enemy.TakeDamage(Damage);
        }
    }

    public override void OnTriggerEnter2D(Collider2D collider) {
        //TODO Need to use this method to figure out what the Player
        //Does when it interacts with Items and Exits (they are called Triggers)
    }

    /// <summary>
    /// Will subtract coins from Player
    /// </summary>
    /// <param name="coinsLost">Amount of coins to lose</param>
    public void LoseCoins(int coinsLost) {
        coins -= coinsLost;

        //If coins are now below 0, let's set to 0
        if (coins < 0) {
            coins = 0;
        }
    }

    /// <summary>
    /// Will disable the Player and End the Level
    /// </summary>
    public void FinishLevel() {
        enabled = false;
        Collider.enabled = false;

        //TODO add more code for finishing level
    }
}
