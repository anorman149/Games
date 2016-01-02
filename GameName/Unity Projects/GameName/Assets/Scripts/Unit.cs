using UnityEngine;

public abstract class Unit : MovementController {
    public int health;
    public int damage;

    public abstract void DealDamage(object obj);
    public abstract void CheckDeath();
    public abstract void TakeDamage(int damage);
    public abstract void OnTriggerEnter2D(Collider2D collider);
}