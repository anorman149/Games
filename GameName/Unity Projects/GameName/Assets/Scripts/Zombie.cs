using UnityEngine;

public class Zombie : Enemy {
    protected override void Start() {
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        Damage = 10;
        Speed = 3f;
        JumpVelocity = 60;
        coinsToTakeAway = 10;

        attackWaitTime = 1f;
        knockBackPower = 6f;
        maxDistanceToPlayer = 2f;

        base.Start();
    }

    public override void OnCollisionEnter2D(Collision2D collision) {
        //Check to see if the Object is a Player
        if(collision.gameObject.tag.Equals("Player")) {
            Player player = collision.gameObject.GetComponent<Player>();

            //We should probably only do damage if the Player is NOT Dead
            if(!player.IsDead() && !player.invulnerable) {
                //Play Animation for taking damage
                Animate(Animation.Attack, "");

                //Let's do some damage and take away coins
                player.ReceiveDamage(Damage);

                //Subtract the necessary amount of coins
                GameManager.instance.SubtractCoins(coinsToTakeAway);

                //Distance between the Enemey and the Player
                Vector3 move = player.transform.position - transform.position;
                move.Normalize();

                //Knock the Player back a little
                StartCoroutine(MovementController.KnockBack(0.02f, knockBackPower, player, move.x));

                //Stop the enemy from moving for a little
                StartCoroutine(UnitController.WaitForSeconds(attackWaitTime, this));
            }
        }
    }
}
