using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Collider2D),typeof(Animator))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask jumpableGround;

    Rigidbody2D rb2;
    BoxCollider2D collider2d;
    Animator animator;

    [HideInInspector] public bool isInputEnabled;
    bool canDoubleJump;

    private enum MovementState { run, jump, doubleJump, fall }

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        isInputEnabled = true;
        canDoubleJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInputEnabled)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (IsGrounded())
                {
                    Jump();

                    canDoubleJump = true;
                }

                else if (canDoubleJump)
                {
                    Jump();

                    canDoubleJump = false;
                }
            }
        }
    }

    void FixedUpdate()
    {
        UpdateAnimationState();
    }

    private void Jump()
    {
        rb2.velocity = new Vector2(0f, jumpForce);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider2d.bounds.center - new Vector3(0, collider2d.bounds.extents.y),
            new Vector3(collider2d.bounds.extents.x * 2, 0.01f), 0f, Vector2.down, 0.01f, jumpableGround);
    }

    private void UpdateAnimationState()
    {
        MovementState currentState = MovementState.run;

        if (rb2.velocity.y > 0.01f) // Jump
        {
            currentState = MovementState.jump;

            if (!canDoubleJump) // If it's false, that means the character has already double jumped.
            {
                currentState = MovementState.doubleJump;
            }
        }

        else if (rb2.velocity.y < -0.01f) // Fall
        {
            currentState = MovementState.fall;
        }

        animator.SetInteger("state", (int)currentState);
    }
}
