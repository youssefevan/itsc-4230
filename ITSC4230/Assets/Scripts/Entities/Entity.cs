using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour // Base class for Player, Sandworms, and Lizards
{

    [SerializeField] public Collider2D vibrationCollider;
    //[SerializeField] public GameObject vibrations;
    //[SerializeField] public float vibrationRate;

    [SerializeField] public TypeEnum vibrationType;
    [SerializeField] GameObject deathParticles;

    public enum TypeEnum {
        Active,
        Sensory,
        Environmental // unused
    }

    public bool canVibrate = true;

    // Die when colliding with sandworm hitbox
    public void HurtboxEnter(Collider2D other) {
        if (other.GetComponentInParent<SandwormHitbox>()) {
            Die();
        }
    }

    // Create particles, play sound, destroy object
    public void Die() {
        Instantiate(deathParticles, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        Destroy(gameObject);
    }

    /*public IEnumerator CreateVibrations() {
        canVibrate = false;
        Instantiate(vibrations, vibrationSpawnPoint);
        StartCoroutine(CreateVibrationsHandler());
        yield return null;
    }

    public IEnumerator CreateVibrationsHandler() {
        yield return new WaitForSeconds(vibrationRate);
        canVibrate = true;
    }*/

}
