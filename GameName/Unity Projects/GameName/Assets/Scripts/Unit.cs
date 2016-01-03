using UnityEngine;

public abstract class Unit : MonoBehaviour {
    public int Health;
    public int Damage;
    public float Speed;
    public float JumpVelocity;
    public bool IsGrounded;
    public bool FacingRight;

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
    /// Will check if the Unit is activated or not (dead or not)
    /// </summary>
    /// <returns></returns>
    public virtual bool IsDead() {
        return !enabled;
    }

    /// <summary>
    /// The FixedUpdate method for the Units to override
    /// </summary>
    public virtual void FixedUpdate() {
        MovementController.ClampUnit(this);
    }
}