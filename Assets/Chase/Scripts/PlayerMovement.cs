using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("get Scripts")]
    public BuyingLvls BuyLvls;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    int AffectedSpeed;


    [Header("Dash")]
    [SerializeField] float dashSpeed = 20f;
    [SerializeField] float dashDuration = 0.2f;
    [SerializeField] float dashCooldown = 3f;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;

    [SerializeField] private AudioClip dashSound;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isDashing;
    private bool canDash = true;

    private Dagger dagger;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dagger = GetComponent<Dagger>();

        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        if ((dagger != null && dagger.isLunging) || isDashing) return;

        if (Mathf.Abs(rb.linearVelocityX) > 0.01f || Mathf.Abs(rb.linearVelocityY) > 0.01f)
        {
            animator.Play("ZachRunAnim");
        }
        else
        {
            animator.Play("ZachIdle");
        }

        // lvl affecting movement
        AffectedSpeed = Mathf.RoundToInt(BuyLvls.HealthLvl * 3);

        moveSpeed = 5 + AffectedSpeed;
        dashSpeed = 20 + AffectedSpeed;
    }

    private void FixedUpdate()
    {
        if (isDashing || (dagger != null && dagger.isLunging)) return;

        rb.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (dagger != null) dagger.MeleeDirection(moveInput);

        if (dagger != null && dagger.isLunging) return;

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
        if (context.performed && !isDashing && canDash)
        {
            AudioSource.PlayClipAtPoint(dashSound, transform.position, 1f);
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

        yield return new WaitForSeconds(dashDuration);

        rb.gravityScale = originalGravity;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
