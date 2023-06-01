using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.velocity = moveInput.normalized * moveSpeed * Time.deltaTime;
    }
    

    private void OnMove(InputValue inputValue) {
        moveInput = inputValue.Get<Vector2>();
    }

}
