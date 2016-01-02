using UnityEngine;

public abstract class MovementController : MonoBehaviour {
    protected Vector3 move = Vector3.zero;

    public float speed;
    public float runSpeed;
    public float jumpSpeed;
    protected bool isGrounded;
    bool facingRight;

    protected Vector3 gravity = Vector3.zero;
    protected BoxCollider2D boxCollider;
    protected Rigidbody2D rigidBody;
    public Transform groundCheck;
    protected float groundRadius = 0.2f;
    public LayerMask theGround;

    protected virtual void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();

        //Set default params
        isGrounded = true;
        facingRight = true;
    }

    protected virtual void FixedUpdate() {
        Move();
    }

    /// <summary>
    /// Will move the Unit while checking for direction
    /// </summary>
    protected void Move() {
        //Move the unit
        rigidBody.velocity = new Vector2(move.x * speed, rigidBody.velocity.y);

        //Clamp the position of the player into the boundaries
        float maxWidth = GameManager.instance.maxWidth - boxCollider.bounds.extents.x;
        transform.position = (new Vector2(Mathf.Clamp(transform.position.x, -maxWidth, maxWidth), transform.position.y));

        //If the unit moved direction
        if (move.x > 0 && !facingRight) {
            Flip();
        } else if(move.x < 0 && facingRight) {
            Flip();
        }

        //Character Animation
        Animate();
    }

    /// <summary>
    /// Will change the direction of the Unit
    /// </summary>
    protected void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    /// <summary>
    /// Trigger Animation
    /// </summary>
    protected abstract void Animate();
}
