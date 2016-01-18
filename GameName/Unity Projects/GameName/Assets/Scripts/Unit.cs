using System.Collections;
using UnityEngine;

public abstract class Unit : MonoBehaviour {
    [HideInInspector]
    public int MaxHealth;

    public float CurrentHealth;
    public float Damage;
    public float AttackRange;
    public float Speed;
    public float JumpVelocity;
    public float AttackSpeed;
    public bool IsGrounded;
    public bool FacingRight;
    public bool Dead = false;
    public bool wait = false;
    public bool invulnerable = false;

    public LayerMask TheGround;
    public Transform GroundCheck;

    //Hide these in Inspector
    [HideInInspector]
    public Animator Animator;
    [HideInInspector]
    public Collider2D Collider;
    [HideInInspector]
    public Rigidbody2D RigidBody;

    public abstract void CheckHealth();
    public abstract void Death();
    public abstract void ReceiveDamage(float damage);
    public abstract void OnTriggerEnter2D(Collider2D collider);

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
    /// <returns>True if the Unit is marked as Dead</returns>
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

    /// <summary>
    /// Will be the Attack method that the subclasses will override. 
    /// Each Unit will have their own Attack method
    /// </summary>
    public virtual void Attack() {
        //Leaving empty for subclasses to override
    }

    /// <summary>
    /// Will be the OnCollision Method that the subclasses will override
    /// Each Unit will have their own Collision Method
    /// </summary>
    public virtual void OnCollisionEnter2D(Collision2D collision) {
        //Leaving empty for subclasses to override
    }

    /// <summary>
    /// Allow the Unit to blink for a duration
    /// </summary>
    /// <param name="duration">Duration fo blinking</param>
    /// <param name="blinkTime">How often the blink occures</param>
    /// <param name="invulnerableForDuration">Whether the Unit should be invulnerable during this time</param>
    /// <returns></returns>
    protected IEnumerator blink(float duration, float blinkTime, bool invulnerableForDuration) {
        if(invulnerableForDuration) {
           invulnerable = true;
        }

        while(duration > 0f) {
            duration -= Time.deltaTime;

            //toggle renderer
            GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;

            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
        }

        //make sure renderer is enabled and invulnerable is not when we exit
        GetComponent<Renderer>().enabled = true;
        invulnerable = false;
    }
}