using UnityEngine;

public class Hero : Player {
    private float bulletSpeed = 15f;

    protected override void Start() {
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        Damage = 50;
        Speed = 4;
        JumpVelocity = 90;
        AttackRange = 8f;

        base.Start();
    }

    public override void Attack() {
        //Let's check current animation, if the Player is already attacking, we don't want to again
        bool attacking = Animator.GetCurrentAnimatorStateInfo(0).IsName(Animation.Attack.ToString()) && !Animator.IsInTransition(0);

        //If the Player Attacked AND they are not currently attacking, do some damage
        if(GameManager.instance.platform.CheckAttack() && !attacking) {
            //Bullet Spawn position
            Vector3 bulletSpawn = GameObject.Find("BulletSpawn").transform.position;

            Animate(Animation.Attack, "");

            //Instantiate the Bullet
            Bullet bullet = Instantiate(Resources.Load("Prefabs/items/Bullet", typeof(Bullet)), bulletSpawn, Quaternion.identity) as Bullet;
            bullet.SetDamage(Damage);
            bullet.SetBulletSpeed(bulletSpeed);
            bullet.SetUnitWhoShot(this);
            bullet.SetSpawnLocation(bulletSpawn);
            bullet.SetBulletRange(AttackRange);
        }
    }
}
