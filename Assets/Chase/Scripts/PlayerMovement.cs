using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Dash")]
    [SerializeField] float dashSpeed = 20f; 
    [SerializeField] float dashDuration = 0.2f; 
    [SerializeField] float dashCooldown = 3f;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isDashing;
    private bool canDash = true; 

    private PlayerCombat playerCombat;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerCombat = GetComponent<PlayerCombat>();

        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();

        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (rb.linearVelocityX != 0 || rb.linearVelocityY != 0)
        {
            animator.Play("ZachRunAnim");
        }
        else
        {
            animator.Play("ZachIdle");
        }

        //animator.SetFloat("Speed", moveInput.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        // If dashing, let the coroutine control the velocity completely
        if (isDashing) return;

        // Apply normal movement physics here
        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        playerCombat.MeleeDirection(moveInput);

        if (moveInput.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (moveInput.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        // Trigger only when button is pressed, if not already dashing, and cooldown is over
        if (context.performed && !isDashing && canDash)
        {
            StartCoroutine(DashRoutine());
        }
    }

    private IEnumerator DashRoutine()
    {
        isDashing = true;
        canDash = false;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        Vector2 dashDirection = moveInput != Vector2.zero ? moveInput.normalized : Vector2.right;

        rb.linearVelocity = dashDirection * dashSpeed;

        // Wait for the configured dash duration
        yield return new WaitForSeconds(dashDuration);

        // Reset movement states
        rb.gravityScale = originalGravity;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
