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
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        
        //float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        rb.AddForce(new Vector2(dir.x, dir.y).normalized * moveSpeed);
    }

    void LateUpdate() {
        lastVelocity = rb.velocity;
    }

    void FixedUpdate() {

        if (rockTiles.GetTile(rockTiles.WorldToCell(transform.position))) {
            canVibrate = false;
        } else {
            canVibrate = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        currentSpeed = lastVelocity.magnitude;
        direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(currentSpeed, 0);
    }

}
