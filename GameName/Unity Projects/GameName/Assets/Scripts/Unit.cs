using UnityEngine;

public abstract class Unit : MovingObject {
    public int health {
        get { return health; }

        set { health = value; }
    }

    public int damage {
        get { return damage; }

        set { damage = value; }
    }

    public abstract void DealDamage(object obj);
    public abstract void CheckDeath();
    public abstract void TakeDamage(int damage);
    public abstract void OnTriggerEnter2D(Collider2D other);
}
