using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
public class PlayerMovement : MonoBehaviour
{
    [Header("Dash")]
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 5f;
    [SerializeField] float dashCooldown = 3f;
    bool isDashing;
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;


    Vector2 moveDirection;
    Vector2 mousePosition;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = moveInput * moveSpeed;
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    private void Dash(InputAction.CallbackContext context)
    {
        // Only trigger the dash when the button is first pressed down
        if (context.performed && !isDashing)
        {
            StartCoroutine(DashRoutine());
        }
    }
    private IEnumerator DashRoutine()
    {
        isDashing = true;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        // Apply the dash velocity
        rb.linearVelocity = moveDirection * dashSpeed;

        // Wait for the duration of the dash (e.g., 0.2 seconds)
        yield return new WaitForSeconds(0.2f);

        // Reset everything back to normal
        rb.gravityScale = originalGravity;
        isDashing = false;
    }

    private void FixedUpdate()
    {
        if (isDashing) return;
        rb.linearVelocity = moveDirection * moveSpeed;
    }



}
