using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrations : MonoBehaviour
{
    [SerializeField] float growthRate;
    [SerializeField] float maxRadius;

    private void Start() {
        transform.localScale = new Vector3(0, 0, 1);
    }

    private void FixedUpdate() {
        if (transform.localScale.x < maxRadius) {
            transform.localScale += new Vector3(growthRate, growthRate, 0) * Time.fixedDeltaTime;
        } else {
            Destroy(gameObject);
        }
    }

}
