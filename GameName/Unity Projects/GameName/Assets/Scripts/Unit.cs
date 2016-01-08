using UnityEngine;

public abstract class Unit : MonoBehaviour {
    public int MaxHealth;
    public int CurrentHealth;
    public int Damage;
    public float Speed;
    public float JumpVelocity;
    public bool IsGrounded;
    public bool FacingRight;
    public bool Dead = false;
    public bool wait = false;

    public LayerMask TheGround;
    public Transform GroundCheck;

    //Hide these in Inspector
    [HideInInspector]
    public Animator Animator;
    [HideInInspector]
    public Collider2D Collider;
    [HideInInspector]
    public Rigidbody2D RigidBody;

    public abstract void DealDamage(GameObject gameObject);
    public abstract void CheckHealth();
    public abstract void Death();
    public abstract void TakeDamage(int damage);
    public abstract void OnTriggerEnter2D(Collider2D collider);
    public abstract void OnCollisionEnter2D(Collision2D collision);

    /// <summary>
    /// Will Animate the Unit with the supplied values
    /// </summary>
    /// <param name="animation">The Animation for the Unit</param>
    /// <param name="value">The value for the Animation</param>
    public void Animate(Animation animation, object value) {
        AnimationMethods.setAnimationTypeAndValue(animation, Animator, value);
    }

    /// <summary>
    /// Check to see if the Dead Animation has been triggered or not (dead or not)
    /// </summary>
    /// <returns></returns>
    public virtual bool IsDead() {
        return Dead;
    }

    /// <summary>
    /// The FixedUpdate method for the Units to override
    /// </summary>
    public virtual void FixedUpdate() {
        MovementController.ClampUnit(this);

        //Check whether we are on the ground or not
        UnitController.UnitOnGround(this);
    }
}