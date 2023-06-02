using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrations : MonoBehaviour
{
    [SerializeField] TypeEnum type;
    [SerializeField] float strength;
    [SerializeField] float growthRate;

    private enum TypeEnum {
        Active,
        Sensory,
        Environmental
    }

    private void Start() {
        transform.localScale = new Vector3(0, 0, 1);
    }

    private void FixedUpdate() {
        if (transform.localScale.x < strength) {
            transform.localScale += new Vector3(growthRate, growthRate, 0) * Time.fixedDeltaTime;
        } else {
            Destroy(gameObject);
        }
    }

}
