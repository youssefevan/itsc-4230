using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    public int sandwormCount; // Amount currently captured
    [SerializeField] public int sandwormsToCapture; // Amount needed to beat level

    private void Start() {
        // Reset sandworms collected
        sandwormCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Check if the incoming object is a sandworm's hitbox
        if (other.gameObject.tag == "Hitbox" && other.gameObject.GetComponentInParent<SandwormController>()) {
            // Add a sandworm
            sandwormCount += 1;
            Debug.Log("Sandworms captured: " + sandwormCount);

            // Check if all sandworms are captured
            if (sandwormCount == sandwormsToCapture) {
                Debug.Log("All sandworms captured");
            }
        }
    }
}
