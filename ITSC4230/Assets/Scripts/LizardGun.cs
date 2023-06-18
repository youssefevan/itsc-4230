using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardGun : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject lizardPrefab;
    [SerializeField] GameObject spriteObject;
    [SerializeField] Transform muzzle;
    Vector3 mousePos;
    bool canFire;
    float timer;
    float firerate = 1.5f;

    void Start()
    {
        canFire = true;

        // Sets safe tiles and camera variables in the lizard prefab to the
        // respective values assigned to the player. This allows for the lizards
        // to have contextually correct references without being set in the inspector.
        lizardPrefab.GetComponent<Lizard>().rockTiles = GetComponentInParent<PlayerController>().rockTiles;
        lizardPrefab.GetComponent<Lizard>().cam = this.cam;
    }

    void Update()
    {
        // Calculates mouse position relative to camera
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        // Calculates rotation based on the position of the mouse
        Vector3 rotation = mousePos - transform.position;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg; // Convert to direction
        transform.rotation = Quaternion.Euler(0, 0, rot); // Sets rotation

        // Vertially flips the gun sprite based on the rotation of the gun.
        // This way, the gun sprite is never upside-down.
        if (transform.rotation.z > (45 * Mathf.Deg2Rad) || transform.rotation.z < (-45 * Mathf.Deg2Rad)) {
            spriteObject.GetComponent<SpriteRenderer>().flipY = true;
        } else {
            spriteObject.GetComponent<SpriteRenderer>().flipY = false;
        }

        // Limits shooting intervals by using a frame-counting timer
        if (canFire == false) {
            timer += Time.deltaTime;
            if(timer > firerate) {
                canFire = true;
                timer = 0;
            }
        }

        // Checks for input and ability to fire,
        // spawns an instance of the lizard prefab at the pos of the muzzle
        if (Input.GetButtonDown("Fire1") && canFire) {
            Instantiate(lizardPrefab, muzzle.position, Quaternion.identity);
            canFire = false;
        }

    }
}
