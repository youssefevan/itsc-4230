using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SandwormController : Entity
{
    private Rigidbody2D rb;

    GameObject target;
    //Vector2 directionVector;
    AIDestinationSetter aiDest;
    
    //public float moveSpeed;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        aiDest = GetComponent<AIDestinationSetter>();
    }

    private void FixedUpdate()
    {
        if (canVibrate == true) {
            StartCoroutine(CreateVibrations());
        }

        aiDest.target = target.transform;

        /*if (target != null) {
            directionVector = (target.transform.position - transform.position).normalized;
            rb.velocity = directionVector * moveSpeed * Time.fixedDeltaTime;
        } else {
            rb.velocity = Vector2.zero;
        }*/

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other is CircleCollider2D) {
            // get game object, check vibration type, assign target
            if (other.gameObject.GetComponent<Entity>() == true) {
                String detectedVibrationType = other.gameObject.GetComponent<Entity>().vibrationType.ToString();
                if (detectedVibrationType == "Active") {
                    target = other.gameObject;
                }
            }
        }
    }

}
