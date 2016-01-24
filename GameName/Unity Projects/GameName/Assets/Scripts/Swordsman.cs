using UnityEngine;

public class Swordsman : Player {
    protected override void Start() {
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        Damage = 50;
        Speed = 4;
        JumpVelocity = 90;
        AttackRange = 4f;

        knockBackPower = 3f;

        base.Start();
    }

    public override void Attack() {
        //Let's check current animation, if the Player is already attacking, we don't want to again
        bool attacking = CheckCurrentAnimationPlaying(Animation.Attack);

        //If the Player Attacked AND they are not currently attacking, do some damage
        if(GameManager.instance.platform.CheckAttack() && !attacking) {
            Animate(Animation.Attack, "");
        }
    }

    public override void OnTriggerEnter2D(Collider2D collider) {
        base.OnTriggerEnter2D(collider);

        if(collider.gameObject.tag.Equals("Enemy")) {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();

            //Make sure the enemy isn't invulnerable first
            if(!enemy.invulnerable) {
                //The enemy needs to take Damage
                enemy.ReceiveDamage(Damage);
            }
        }
    }
}
