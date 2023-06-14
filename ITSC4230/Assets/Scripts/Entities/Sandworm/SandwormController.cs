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
    [SerializeField] public Collider2D hitbox;
    public Collider2D eatTarget = null;

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

    public void VibrationColliderEnter(Collider2D other) {
        /*if (other.tag == "Vibration") {
            // get game object, check vibration type, assign target
            String detectedVibrationType = other.gameObject.transform.parent.gameObject.GetComponentInParent<Entity>().vibrationType.ToString();
            if (detectedVibrationType == "Active") {
                target = other.gameObject.transform.parent.gameObject;
            }
        }*/
    }

    public void VibrationColliderStay(Collider2D other) {
        if (other.tag == "Vibration") {
            // get game object, check vibration type, assign target
            String detectedVibrationType = other.gameObject.transform.parent.gameObject.GetComponentInParent<Entity>().vibrationType.ToString();
            if (detectedVibrationType == "Active") {
                target = other.gameObject.transform.parent.gameObject;
            }
        }
    }

    public void VibrationColliderExit(Collider2D other) {
        if (other.tag == "Vibration") {
            if (other.gameObject.transform.parent.gameObject.GetComponentInParent<Entity>() == true) {
                if (other.gameObject.transform.parent.gameObject == target) {
                    target = null;
                }
            }
        }
    }

    public void HitboxEnter(Collider2D other) {
        if (other.tag == "Hurtbox") {
            eatTarget = other;
        }
    }

    public void HitboxExit(Collider2D other) {
        if (other.tag == "Hurtbox") {
            eatTarget = null;
        }
    }
    
}
