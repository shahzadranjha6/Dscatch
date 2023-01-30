using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class catchermovent : MonoBehaviour
{
    
    private int Bound = 14; 
    //horizontal movement for playercontrols for buttons
    // Vector2 horizotal = Vector2.zero;
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
    int speed = 10;
    public InputAction playerControls;







    [Header("Damage VFX")]
    [Tooltip("VFX to play when the player takes damage")]
    [SerializeField] private ParticleSystem damageVFX;
    private Vector3 orignalCamPos;


    private void Start()
    {
        orignalCamPos = Camera.main.transform.position;


        rb = GetComponent<Rigidbody2D>();

        transform.position = new Vector2(0, -3.2853f);  // should spawn from starting Position

        AudioManager_Script.instance.Play("theme");
    }
    //reading value of input by canvas button
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            leftMove();
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rightMove();
        }


        // horizotal = playerControls.ReadValue<Vector2>();
        
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

    void FixedUpdate()
        {
            rb.AddForce(new Vector2(horizontal_Speed * speed, 0), ForceMode2D.Impulse  );
        }
   
    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("BlackToken"))
    //         {
    //         collision.gameObject.SetActive(false);
    //             // AudioManager.instance.PlaySound();
    //             AudioManager_Script.instance.Play("collect");
    //             UIManager.instance.ScoreUpdate();
    //             Debug.Log("collected");
    //         }   
    //         else if (collision.CompareTag("RedToken"))
    //         {
    //             collision.gameObject.SetActive(false);
    //             // AudioManager.instance.PlaySound();

    //             AudioManager_Script.instance.Play("damage");
    //             UIManager.instance.ScoreUpdateMinus();
    //             Debug.Log("collected");
    //         }
    // }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BlackToken"))
        {
            collision.gameObject.SetActive(false);
            // AudioManager.instance.PlaySound();
            AudioManager_Script.instance.Play("collect");

            UIManager.instance.ScoreUpdate();
            Debug.Log("collected");
        }
        else if (collision.gameObject.CompareTag("RedToken"))
        {
            collision.gameObject.SetActive(false);
            // AudioManager.instance.PlaySound();


            UIManager.instance.ScoreUpdateMinus();
            Debug.Log("collected");

            AudioManager_Script.instance.Play("damage");

            StartCoroutine("CameraShake");      //-- shake cam

            damageVFX.Play();
        }


    }


    #region TouchMovement
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
    #endregion
    
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



    // --- camera shake

    // private IEnumerator CameraShake()
    //     {
    //         for (int i = 0; i < 5; i++)
    //         {
    //             Camera cam = Camera.main;       //--- using for camera shake

    //             Vector2 randomPos = UnityEngine.Random.insideUnitCircle * 0.2f;     //--> generating a random value


    //             cam.transform.position = new Vector3(UnityEngine.Random.Range(cam.transform.position.x , cam.transform.position.x+.3f)  , cam.transform.position.y , cam.transform.position.z );  //-->> set randomly generated position

    //             yield return new WaitForSeconds(0.01f);
    //             // yield return null;
    //             // yield return null;      //-->> this means we wait for the current frame to be finished(returning null)
    //                                         //--> after returning the loop will run again [method will not terminate]
    //         }   

    //         Camera.main.transform.position = orignalCamPos;         //-->> again setting the position to default position
    //     }

    private IEnumerator CameraShake()
        {
            if(UIManager.instance.Seconds >2f)
                {
                    Camera cam = Camera.main;
                    Vector3 originalPos = cam.transform.position;

                    float shakeDuration = 0.3f; // adjust duration to your liking
                    float shakeAmount = 0.2f; // adjust amount to your liking

                    float startTime = Time.time;

                    while (Time.time < startTime + shakeDuration)
                    {
                        Vector2 randomPos = UnityEngine.Random.insideUnitCircle * shakeAmount;
                        cam.transform.position = new Vector3(originalPos.x + randomPos.x, originalPos.y + randomPos.y, originalPos.z);

                        yield return null;
                    }

                    cam.transform.position = originalPos;
                }

        }

}