using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwormController : Entity
{
    private void FixedUpdate()
    {
        if (canVibrate == true) {
            StartCoroutine(CreateVibrations());
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other is CircleCollider2D) {
            // get game object, check vibration type
            if (other.gameObject.GetComponent<Entity>() == true) {
                Debug.Log(other.gameObject.GetComponent<Entity>().vibrationType);
            }
        }
    }

}
