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
        lizardPrefab.GetComponent<Lizard>().rockTiles = GetComponentInParent<PlayerController>().rockTiles;
        lizardPrefab.GetComponent<Lizard>().cam = this.cam;
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        if (transform.rotation.z > (45 * Mathf.Deg2Rad) || transform.rotation.z < (-45 * Mathf.Deg2Rad)) {
            spriteObject.GetComponent<SpriteRenderer>().flipY = true;
        } else {
            spriteObject.GetComponent<SpriteRenderer>().flipY = false;
        }

        if (!canFire) {
            timer += Time.deltaTime;
            if(timer > firerate) {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetButtonDown("Fire1") && canFire) {
            Instantiate(lizardPrefab, muzzle.position, Quaternion.identity);
            canFire = false;
        }

    }
}
