using UnityEngine;

public class Bullet : MonoBehaviour {
    private float bulletSpeed;
    private float bulletRange;
    private Vector3 locationSpawned;
    private Unit unitWhoShot;
    private float damage;
    private float secondsToLive = 5;

    private void Start () {
        //Check the direction the bullet needs to go
        if(!unitWhoShot.FacingRight) {
            bulletSpeed = -bulletSpeed;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        //Allows the Bullet to live for secondsToLive
        //This will be just in-case it didn't hit anything
        Destroy(gameObject, secondsToLive);
    }

    private void FixedUpdate() {
        //Add Force to the Bullet
        GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
    }

    private void Update() {
        //We need to make sure the Bullet stays within the Unit's Attack Range
        if(Vector3.Distance(transform.position, locationSpawned) > bulletRange) {
            //Bullet is out of range, destroy it
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag.Equals("Enemy")) {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            //Make sure the enemy isn't invulnerable first
            if(!enemy.invulnerable) {
                //The enemy needs to take Damage
                enemy.ReceiveDamage(damage);
            }

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

    /// <summary>
    /// Will tell the Bullet who the Owner is
    /// </summary>
    /// <param name="unit">Owner of the Bullet (who shot it)</param>
    public void SetUnitWhoShot(Unit unit) {
        unitWhoShot = unit;
    }

    /// <summary>
    /// Will set the Bullet's Range it's allowed to travel
    /// </summary>
    /// <param name="range">Range allowed to travel before destroyed</param>
    public void SetBulletRange(float range) {
        bulletRange = range;
    }

    /// <summary>
    /// Will set the Location where the Bullet Spawns
    /// </summary>
    /// <param name="location">Location where the Bullet Spawns</param>
    public void SetSpawnLocation(Vector3 location) {
        locationSpawned = location;
    }
}
