using UnityEngine;
using System;

public class Enemy : Unit {

    protected Animator animator;
    private Transform target;

    public int coinsToTakeAway {
        get { return coinsToTakeAway; }

        set { coinsToTakeAway = value; }
    }

    protected override void Start () {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        base.Start();
	}

    public override void DealDamage(object obj) {
        //Check to see if the Object is a Player
        if (obj is Player) {
            Player player = obj as Player;

            //Let's do some damage and take away coins
            player.TakeDamage(damage);
            player.LoseCoins(coinsToTakeAway);
        }
    }

    public override void TakeDamage(int damage) {
        health -= damage;

        //Need to check and see if the Enemy died
        CheckDeath();
    }

    public void MoveEnemy() {
        int xDir = 0;
        int yDir = 0;

        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon) {
            yDir = target.position.y > transform.position.y ? 1 : -1;
        } else {
            xDir = target.position.x > transform.position.x ? 1 : -1;
        }

        AttemptMove<Player>(xDir);
    }

    public override void CheckDeath() {
        if (health <= 0) {
            enabled = false;
        }
    }

    protected override void onCantMove<T>(T component) {
        Player hitPlayer = component as Player;

        hitPlayer.TakeDamage(damage);
    }

    public override void OnTriggerEnter2D(Collider2D other) {
        throw new NotImplementedException();
    }
}
