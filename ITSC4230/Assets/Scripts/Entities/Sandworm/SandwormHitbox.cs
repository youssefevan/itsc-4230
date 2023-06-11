using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwormHitbox : MonoBehaviour
{
    [SerializeField] private GameObject parent;

    private void OnTriggerEnter2D(Collider2D other) {
        parent.GetComponent<SandwormController>().HitboxEnter(other);
    }

    private void OnTriggerExit2D(Collider2D other) {
        parent.GetComponent<SandwormController>().HitboxExit(other);
    }
}
