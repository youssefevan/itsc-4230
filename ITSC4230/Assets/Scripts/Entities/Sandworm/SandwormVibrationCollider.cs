using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwormVibrationCollider : MonoBehaviour
{

    [SerializeField] private GameObject parent;

    private void OnTriggerEnter2D(Collider2D other) {
        parent.GetComponent<SandwormController>().VibrationColliderEnter(other);
    }

    private void OnTriggerStay2D(Collider2D other) {
        parent.GetComponent<SandwormController>().VibrationColliderStay(other);
    }

    private void OnTriggerExit2D(Collider2D other) {
        parent.GetComponent<SandwormController>().VibrationColliderExit(other);
    }
}
