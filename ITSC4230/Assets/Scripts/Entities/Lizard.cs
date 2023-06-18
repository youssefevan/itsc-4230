using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Lizard : Entity
{
    // Lizards bounce around the level and distract the sandworms

    [SerializeField] public Tilemap rockTiles;
    [SerializeField] public Collider2D hurtbox;
    Rigidbody2D rb;
    Vector3 mousePos;
    Vector3 lastVelocity;
    float currentSpeed;
    Vector3 direction;

    public Camera cam;

    private float moveSpeed = 50f;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); // mouse position relative to camera

        // Calculates the direction of the mouse cursor in relation to the lizard
        Vector3 dir = mousePos - transform.position;

        // Launches the lizards in the calculated direction
        rb.AddForce(new Vector2(dir.x, dir.y).normalized * moveSpeed);
    }

    void LateUpdate() {
        lastVelocity = rb.velocity;
    }

    void FixedUpdate() {
        //Debug.Log(rb.velocity.magnitude);

        // Checks if the lizard is on rock tiles (aka safe tiles)
        // and adjusts vibrations accordingly.
        if (rockTiles.GetTile(rockTiles.WorldToCell(transform.position))) {
            canVibrate = false;
        } else {
            if (rb.velocity.magnitude > 0.075){ // if moving enough
                canVibrate = true;
            } else {
                canVibrate = false;
            }
        }
    }

    // Detects collisions with walls and bounces based on the latest
    // velocity and the normal of thw wall.
    private void OnCollisionEnter2D(Collision2D other) {
        currentSpeed = lastVelocity.magnitude;
        direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(currentSpeed, 0);
    }

}
