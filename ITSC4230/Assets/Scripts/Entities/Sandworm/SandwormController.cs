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
    public bool foundFood = false;
    public bool captured = false;
    [SerializeField] GameObject bodySegment;
    int wormLength = 8; // Number of body segments
    [SerializeField] public GameObject burrowParticles;
    [SerializeField] AudioClip burrowSFX;

    List<GameObject> wormSegments = new List<GameObject>();
    List<Vector3> positionHistory = new List<Vector3>();
    int offset = 4;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        aiDest = GetComponent<AIDestinationSetter>();
        stateManager = GetComponent<StateManager>();
        gameObject.transform.position = territory.transform.position;
        foundFood = false;
        captured = false;
        AddSegments();
    }

    public void FixedUpdate()
    {
        if (target != null) {
            targetDistance = Vector2.Distance(transform.position, target.transform.position);

            if (target.GetComponent<Entity>() == true && target.GetComponent<Entity>().canVibrate == false) {
                target = null;
            }
        }

        positionHistory.Insert(0, transform.position);

        int index = 0;
        foreach (var segment in wormSegments) {
            Vector3 point = positionHistory[Mathf.Min(index * offset, positionHistory.Count - 1)];
            segment.transform.position = point;
            index++;
        }
    }

    public void Burrow() {
        Instantiate(burrowParticles, gameObject.transform);
        soundManager.GetComponent<SoundManager>().PlaySound(burrowSFX);
    }

    void AddSegments() {
        for (int i = 0; i < wormLength; i++) {
            // Create instance of the body segment, add segment to list
            GameObject segment = Instantiate(bodySegment);
            wormSegments.Add(segment); 
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
        if (other.gameObject.tag == "Hurtbox") {
            foundFood = true;
        } else if (other.gameObject.GetComponentInParent<Pen>()) {
            captured = true;
            territory = other.gameObject;
        }
    }

    public void Die() {
        for (int i = 0; i < wormSegments.Count; i++) {
            Destroy(wormSegments[i].gameObject);
        }
        base.Die();
    }
    
}
