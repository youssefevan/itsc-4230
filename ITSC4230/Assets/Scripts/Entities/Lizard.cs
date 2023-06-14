using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Lizard : Entity
{
    // Lizards bounce around the level and distract the sandworms

    [SerializeField] Tilemap rockTiles;
    [SerializeField] public Collider2D hurtbox;
    Rigidbody2D rb;

    [SerializeField] float moveSpeed = 18f;

    private Vector2 vel;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        vel = new Vector2(-1, -1);
    }

    void FixedUpdate() {
        if (rockTiles.GetTile(rockTiles.WorldToCell(transform.position))) {
            canVibrate = false;
        } else {
            canVibrate = true;
        }

        rb.velocity = vel * moveSpeed * Time.deltaTime;
    }

}
