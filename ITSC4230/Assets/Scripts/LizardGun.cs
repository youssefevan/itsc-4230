using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardGun : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject lizardPrefab;
    [SerializeField] GameObject spriteObject;
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject cooldownUI;
    Vector3 mousePos;
    bool canFire;
    float timer;
    float firerate = 1f;
    [SerializeField] AudioClip shootSFX;

    bool vibrationBuffer = false;
    int vibrationBufferFrames = 20;
    int frame = 100;

    GameObject soundManager;

    void Start()
    {
        canFire = true;
        soundManager = GetComponentInParent<PlayerController>().soundManager;
        // Sets safe tiles, camera, and sound manager variables in the lizard prefab to the
        // respective values assigned to the player. This allows for the lizards
        // to have contextually correct references without being set in the inspector.
        lizardPrefab.GetComponent<Lizard>().rockTiles = GetComponentInParent<PlayerController>().rockTiles;
        lizardPrefab.GetComponent<Lizard>().cam = this.cam;
        lizardPrefab.GetComponent<Lizard>().soundManager = GetComponentInParent<PlayerController>().soundManager;
    }

    void FixedUpdate() {
        // This creates a 20-frame buffer after shooting where the player
        // can move without being detected. This provides some leeway to the player

        if (vibrationBuffer == true) { // True on shoot
            frame += 1; // counts frames
            GetComponentInParent<PlayerController>().canVibrate = false; // disables vibrations

            if (frame == vibrationBufferFrames) { // checks if 20 frames have passed
                // disables buffer, allowing player controller to dictate vibrations
                vibrationBuffer = false;
            }
            
        } else {
            frame = 100;
        }
        
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
            cooldownUI.SetActive(true); // Activates the cooldown ui

            timer += Time.deltaTime;
            if(timer > firerate) {
                canFire = true;
                timer = 0;
            }
        } else {
            // deactivates cooldown ui, resets the bar size
            cooldownUI.SetActive(false);
            cooldownUI.GetComponent<CooldownUI>().ResetBar();
        }

        // Checks for input and ability to fire,
        // spawns an instance of the lizard prefab at the pos of the muzzle
        if (Input.GetButtonDown("Fire1") && canFire) {
            Instantiate(lizardPrefab, muzzle.position, Quaternion.identity);
            soundManager.GetComponent<SoundManager>().PlaySound(shootSFX);
            canFire = false;

            // Setup for buffer
            vibrationBuffer = true;
            frame = 0;
        }

    }
}
