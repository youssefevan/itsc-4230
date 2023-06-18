using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private int neededParts = 3;

    /*private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Hurtbox") {
            var player = other.gameObject.GetComponentInParent<PlayerController>();
            if (player) {
                if (player.collectedParts >= neededParts) {
                    Debug.Log("Found enough parts.");
                } else {
                    Debug.Log("Not enough parts");
                }
            }
        }
    }*/
}
