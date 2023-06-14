using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Hurtbox") {
            if (other.gameObject.GetComponentInParent<PlayerController>()) {
                other.gameObject.GetComponentInParent<PlayerController>().Pickup(this.gameObject);
            }
        }
    }
}
