using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerController : Entity
{
    Vector2 moveInput;
    Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 50.0f;
    [SerializeField] private Tilemap rockTiles;
    [SerializeField] public Collider2D hurtbox;

    public int collectedParts = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hurtbox.enabled = true;
        collectedParts = 0;
    }

    private void FixedUpdate() {
        rb.velocity = moveInput.normalized * moveSpeed * Time.fixedDeltaTime;

        if (rb.velocity != Vector2.zero) {
            if (canVibrate == true) {
                //StartCoroutine(CreateVibrations());
                vibrationCollider.enabled = true;
            } else {
                vibrationCollider.enabled = false;
            }
        } else {
            vibrationCollider.enabled = false;
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

    public void Pickup(GameObject item) {
        collectedParts += 1;
        Debug.Log("Parts collected: " + collectedParts);
        Destroy(item);
    }

}
