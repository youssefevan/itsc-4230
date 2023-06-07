using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerController : Entity
{
    Vector2 moveInput;
    Rigidbody2D rb;
    CircleCollider2D vibrationCircle;
    [SerializeField] private float moveSpeed = 50.0f;
    [SerializeField] private Tilemap rockTiles;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vibrationCircle = GetComponent<CircleCollider2D>();
    }

    private void FixedUpdate() {
        rb.velocity = moveInput.normalized * moveSpeed * Time.fixedDeltaTime;

        if (rb.velocity != Vector2.zero) {
            if (canVibrate == true) {
                //StartCoroutine(CreateVibrations());
                vibrationCircle.enabled = true;
            } else {
                vibrationCircle.enabled = false;
            }
        } else {
            vibrationCircle.enabled = false;
        }

        if (rockTiles.GetTile(rockTiles.WorldToCell(transform.position))) {
            canVibrate = false;
        } else {
            canVibrate = true;
        }

    }

    private void OnMove(InputValue inputValue) {
        moveInput = inputValue.Get<Vector2>();
    }

}
