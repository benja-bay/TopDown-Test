using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    
    private Rigidbody2D playerRb2d;
    private Vector2 moveInput; // creamos un vector para almacenar el movimiento del jugador 
    private Animator playerAnimator;
    void Start()
    {
        playerRb2d = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // inputs
        float moveX = Input.GetAxisRaw("Horizontal");   // Movimiento en X (A/D o Flechas)
        float moveY = Input.GetAxisRaw("Vertical");     // Movimiento en Y (W/S o Flechas)
        moveInput = new Vector2(moveX, moveY).normalized; // Almacena el valor de movex e movey en sus valores 
                                                          // normalized es para normalizar el vector tenga magnitud 1
        
        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        // physics
        playerRb2d.MovePosition(playerRb2d.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
