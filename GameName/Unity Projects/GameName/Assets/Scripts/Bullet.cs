using UnityEngine;

public class Bullet : MonoBehaviour {
    private float bulletSpeed;
    private Player player;
    private float damage;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        //Check the direction the bullet needs to go
        if(!player.FacingRight) {
            bulletSpeed = -bulletSpeed;
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
	
	void FixedUpdate() {
        //Add Force to the Bullet
        GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag.Equals("Enemy")) {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            //The enemy needs to take Damage
            enemy.ReceiveDamage(damage);

            //Now that it hit something, destroy the bullet
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Damage for the bullet
    /// </summary>
    /// <param name="damageToDeal">Amount of damage to assign to the bullet</param>
    public void SetDamage(float damageToDeal) {
        damage = damageToDeal;
    }

    /// <summary>
    /// Will set the Bullet Speed
    /// </summary>
    /// <param name="bulletSpeedToSet">Bullet Speed to Set</param>
    public void SetBulletSpeed(float bulletSpeedToSet) {
        bulletSpeed = bulletSpeedToSet;
    }
}
