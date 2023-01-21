using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class catchermovent : MonoBehaviour
{
    
    private int Bound = 12; 
    Vector2 horizotal = Vector2.zero;
    int speed = 15;
    private Rigidbody2D rb;
    
    //Playermovement control by input system
    public InputAction playerControls;
    
    //enabling Player Controls
    private void OnEnable()
    {
        playerControls.Enable();
    }
    //disable player control
    private void OnDisable()
    {
        playerControls.Disable();
    }
    //rigidbody reference passed to script
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //reading value of inputsystem
    void Update()
    {
        horizotal = playerControls.ReadValue<Vector2>();
    //bounding player movement to the camera
        if (transform.position.x >= Bound)
        {
            transform.position = new Vector2(Bound, transform.position.y);

        }

        if (transform.position.x <= -Bound)
        {
            transform.position = new Vector2(-Bound, transform.position.y);
        }
    }
    //setting velocity of player
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizotal.x * speed,horizotal.y*0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
            {
            collision.gameObject.SetActive(false);
                AudioManager.instance.PlaySound();
                UIManager.instance.ScoreUpdate();
                Debug.Log("collected");
            }
    }
}