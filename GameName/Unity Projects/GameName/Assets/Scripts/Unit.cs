using UnityEngine;

public abstract class Unit : MonoBehaviour {
    public int Health;
    public int Damage;
    public float Speed;
    public float JumpSpeed;
    public bool IsGrounded;
    public bool FacingRight;
    public Animator Animator;
    public Collider2D Collider;
    public Rigidbody2D RigidBody;
    public LayerMask TheGround;
    public Transform GroundCheck;

    public abstract void DealDamage(object obj);
    public abstract void CheckDeath();
    public abstract void TakeDamage(int damage);
    public abstract void OnTriggerEnter2D(Collider2D collider);

    /// <summary>
    /// Will Animate the Unit with the supplied values
    /// </summary>
    /// <param name="animation">The Animation for the Unit</param>
    /// <param name="value">The value for the Animation</param>
    public void Animate(Animation animation, object value) {
        AnimationMethods.setAnimationTypeAndValue(animation, Animator, value);
    }
}