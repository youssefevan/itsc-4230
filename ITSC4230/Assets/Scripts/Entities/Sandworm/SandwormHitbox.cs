using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwormHitbox : MonoBehaviour
{
    // Reference to sandworm
    [SerializeField] private GameObject parent;

    // These call associated methods in SW controller which take in the incoming/exiting collider
    private void OnTriggerEnter2D(Collider2D other) {
        parent.GetComponent<SandwormController>().HitboxEnter(other);
    }

    private void OnTriggerExit2D(Collider2D other) {
        //parent.GetComponent<SandwormController>().HitboxExit(other);
    }
}
