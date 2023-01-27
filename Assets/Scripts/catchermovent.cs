using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class catchermovent : MonoBehaviour
{
    
    // private int Bound = 14; 
    //horizontal movement for playercontrols for buttons
    //Vector2 horizotal = Vector2.zero;
    private Rigidbody2D rb;

    //moveleft bool assign to left UI button
    private bool moveleft = false;
    //moveright bool assign to right UI button
    private bool moveright = false;

    [Header("Movement Variables")]
    [Tooltip("Horizontal Speed of the player")]
    [SerializeField]
    private int horizontal_Speed;
    [SerializeField]
    int speed = 20;

    //
    // //Playermovement control by input system
    // public InputAction playerControls;
    //
    // //enabling Player Controls
    // private void OnEnable()
    // {
    //     playerControls.Enable();
    // }
    // //disable player control
    // private void OnDisable()
    // {
    //     playerControls.Disable();
    // }
    //rigidbody reference passed to script
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        transform.position = new Vector2(0, -3.2853f);  // should spawn from starting Position
    }
    //reading value of input by canvas button
    void Update()
    {
        // if (moveleft)
        // {
        //     leftMove();
        // }
        // else if (moveright)
        // {
        //     rightMove();
        // }

        // rb.AddForce(new Vector2(horizontal_Speed * Time.deltaTime, 0));

        // horizotal = playerControls.ReadValue<Vector2>();
        // touchMove() //touch move method 
        
        //bounding player movement to the camera
        // if (transform.position.x >= Bound)
        // {
        //     transform.position = new Vector2(Bound, transform.position.y);
    
        // }
    
        // if (transform.position.x <= -Bound)
        // {
        //     transform.position = new Vector2(-Bound, transform.position.y);
        // }
    }

    void FixedUpdate()
        {
            rb.AddForce(new Vector2(horizontal_Speed * speed, 0), ForceMode2D.Impulse  );
        }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BlackToken"))
            {
            collision.gameObject.SetActive(false);
                AudioManager.instance.PlaySound();
                UIManager.instance.ScoreUpdate();
                Debug.Log("collected");
            }   
            else if (collision.CompareTag("RedToken"))
            {
                collision.gameObject.SetActive(false);
                AudioManager.instance.PlaySound();
                UIManager.instance.ScoreUpdateMinus();
                Debug.Log("collected");
            }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BlackToken"))
        {
            collision.gameObject.SetActive(false);
            AudioManager.instance.PlaySound();
            UIManager.instance.ScoreUpdate();
            Debug.Log("collected");
        }
        else if (collision.gameObject.CompareTag("RedToken"))
        {
            collision.gameObject.SetActive(false);
            AudioManager.instance.PlaySound();
            UIManager.instance.ScoreUpdateMinus();
            Debug.Log("collected");
        }
    }

    //touch movement
    // void touchMove()
    // {
    //     if (Input.GetMouseButton(0))
    //     {
    //         Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //
    //         if (mousePos.x < -1)
    //         {
    //             //move left
    //             rb.velocity = new Vector2(-speed ,0);
    //             
    //         }
    //         else if (mousePos.x > 1)
    //         {
    //             //move right
    //             rb.velocity = new Vector2(speed, 0);
    //         }
    //         
    //     }
    // }
    
    //left movement button UI
     public void leftMove()
    {
        rb.velocity = new Vector2(-speed,0);

    }
     //right movement button UI
    public void rightMove()
    {
        rb.velocity = new Vector2(speed, 0);
    }



    public void horizontalMovement(int got_Speed)
        {
            Debug.Log("horizontal movement called");
            horizontal_Speed = got_Speed;
        }


}