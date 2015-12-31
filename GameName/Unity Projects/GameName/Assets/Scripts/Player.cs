using UnityEngine;

public class Player : Unit {
    private int coins;
    private int lives;

    protected Animator animator;

    // Use this for initialization
    protected override void Start () {
        animator = GetComponent<Animator>();
        coins = GameManager.instance.playerCoins;
        lives = GameManager.instance.playerLives;

        base.Start();	
	}

    private void OnDisable() {
        GameManager.instance.playerCoins = coins;
        GameManager.instance.playerLives = lives;
    }
	
	// Update is called once per frame
	void Update () {
        int horizontal = (int)Input.GetAxisRaw("Horizontal");
        int vertical = (int)Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0) {
            AttemptMove<Enemy>(horizontal, vertical);
        }
	}

    protected override void AttemptMove <T>(int xDir, int yDir) {
        RaycastHit2D hit;

        if (Move(xDir, yDir, out hit)) {
            //TODO play sound or something
        }
    }

    protected override void onCantMove<T>(T component) {
        //Need to make sure it's an Enemy
        //If so, the Enemy will do damage; caused by running into an Enemy
        if (component is Enemy) {
            Enemy enemy = component as Enemy;

            enemy.DealDamage(this);
        }
    }

    public override void TakeDamage(int damage) {
        health -= damage;

        //Need to check and see if we died
        CheckDeath();
    }

    public override void CheckDeath() {
        if (health <= 0) {
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

    public override void DealDamage(object obj) {
        //Check to see if the Object is an Enemy
        if (obj is Enemy) {
            Enemy enemy = obj as Enemy;

            //Let's do some damage
            enemy.TakeDamage(damage);
        }
    }

    public override void OnTriggerEnter2D(Collider2D other) {
        //TODO Need to use this method to figure out what the Player
        //Does when it interacts with Items and Exits (they are called Triggers)
    }

    public void LoseCoins(int coinsLost) {
        coins -= coinsLost;

        //If coins are now below 0, let's set to 0
        if (coins < 0) {
            coins = 0;
        }
    }
}
