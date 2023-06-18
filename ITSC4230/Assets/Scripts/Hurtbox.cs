using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    [SerializeField] GameObject parent;

    private void OnTriggerEnter2D(Collider2D other) {
        parent.GetComponent<Entity>().HurtboxEnter(other);
    }
}
