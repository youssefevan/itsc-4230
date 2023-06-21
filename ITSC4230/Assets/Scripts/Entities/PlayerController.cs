using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerController : Entity
{
    Vector2 moveInput;
    Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 50.0f;
    [SerializeField] public Tilemap rockTiles;
    [SerializeField] public Collider2D hurtbox;

    public int lizardAmmo = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hurtbox.enabled = true;
        lizardAmmo = 0;
    }

    private void FixedUpdate() {
        // Moves player based on input
        rb.velocity = moveInput.normalized * moveSpeed * Time.fixedDeltaTime;

        // Enables the vibration collider when moving on sand
        if (rb.velocity != Vector2.zero) {
            if (canVibrate == true) {
                vibrationCollider.enabled = true;
            } else {
                vibrationCollider.enabled = false;
            }
        } else {
            vibrationCollider.enabled = false;
        }

        // Disables the player's ability to create vibrations based on
        // whether the player is on safe tiles.
        if (rockTiles.GetTile(rockTiles.WorldToCell(transform.position))) {
            canVibrate = false;
        } else {
            canVibrate = true;
        }
    }

    // Movement input
    private void OnMove(InputValue inputValue) {
        moveInput = inputValue.Get<Vector2>();
    }

    // Ammo system (unused)
    public void Pickup(GameObject item) {
        lizardAmmo += 1;
        Debug.Log("Ammo: " + lizardAmmo);
        Destroy(item);
    }

}
