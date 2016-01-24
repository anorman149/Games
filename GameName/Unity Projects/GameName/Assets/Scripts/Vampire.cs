using UnityEngine;

public class Vampire : Enemy {
    protected override void Start() {
        MaxHealth = 150;
        CurrentHealth = MaxHealth;
        Damage = 20;
        Speed = 3f;
        JumpVelocity = 60;
        coinsToTakeAway = 20;

        attackWaitTime = 1f;
        knockBackPower = 6f;
        maxDistanceToPlayer = 2f;

        base.Start();
    }

    public override void OnCollisionEnter2D(Collision2D collision) {
        //Check to see if the Object is a Player
        if(collision.gameObject.tag.Equals("Player")) {
            Player player = collision.gameObject.GetComponent<Player>();

            //Let's check current animation, if the enemy is hurt, they shouldn't attack again
            bool hurt = CheckCurrentAnimationPlaying(Animation.Damage);

            //We should probably only do damage if the Player is NOT Dead
            if(!player.IsDead() && !player.invulnerable && !hurt) {
                //Play Animation for taking damage
                Animate(Animation.Attack, "");

                //Let's do some damage and take away coins
                player.ReceiveDamage(Damage);

                //Subtract the necessary amount of coins
                GameManager.instance.SubtractCoins(coinsToTakeAway);

                //Distance between the Enemy and the Player
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
