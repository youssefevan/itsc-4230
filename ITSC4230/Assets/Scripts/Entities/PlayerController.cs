using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Entity
{
    Vector2 moveInput;
    Rigidbody2D rb;
    CircleCollider2D vibrationCircle;
    [SerializeField] private float moveSpeed = 50.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vibrationCircle = GetComponent<CircleCollider2D>();
    }

    private void FixedUpdate() {
        rb.velocity = moveInput.normalized * moveSpeed * Time.fixedDeltaTime;

        if (rb.velocity != Vector2.zero && canVibrate == true) {
            vibrationCircle.enabled = true;
            StartCoroutine(CreateVibrations());
        } else {
            vibrationCircle.enabled = false;
        }

    }

    private void OnMove(InputValue inputValue) {
        moveInput = inputValue.Get<Vector2>();
    }

}
