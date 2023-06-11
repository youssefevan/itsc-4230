using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SandwormController: Entity
{

    [SerializeField] public GameObject territory;

    private Rigidbody2D rb;
    StateManager stateManager;

    public AIDestinationSetter aiDest;
    public GameObject target;
    public Transform lastTargetTransform;
    public float targetDistance;
    public float maxEatingDist = 0.1f;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        aiDest = GetComponent<AIDestinationSetter>();
        stateManager = GetComponent<StateManager>();
    }

    public void FixedUpdate()
    {
        if (target != null) {
            targetDistance = Vector2.Distance(transform.position, target.transform.position);

            if (target.GetComponent<Entity>() == true && target.GetComponent<Entity>().canVibrate == false) {
                target = null;
            }
        }
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

    private void OnTriggerExit2D(Collider2D other) {
        if (other is CircleCollider2D) {
            if (other.gameObject.GetComponent<Entity>() == true) {
                if (other.gameObject == target) {
                    target = null;
                }
            }
        }
        
    }
}
