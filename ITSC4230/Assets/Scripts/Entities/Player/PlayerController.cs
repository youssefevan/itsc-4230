using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if(moveInput != Vector2.zero) {
            int count = rb.Cast {
                
            }
        }
    }
    

    void OnMove(InputValue moveValue) {
        moveInput = moveValue.Get<Vector2>();
    }

}
