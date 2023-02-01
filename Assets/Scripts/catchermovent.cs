using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.UI;


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

    private float player_positionY;




    // for touch input declare a slider
    [SerializeField] private GameObject slider;



    [Header("Damage VFX")]
    [Tooltip("VFX to play when the player takes damage")]
    [SerializeField] private ParticleSystem damageVFX;
    private Vector3 orignalCamPos;



    //////////////////////////////////
        // Touch Slider Controls
        [Space(20)]
        [Header("Touch Controls")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float pushForce;
        // [SerializeField] private SliderControls touchSlider;
        // make a Slider COntrol
        [SerializeField] private SliderControls touchSlider;
      [SerializeField]  private bool isPointerDown;
      [SerializeField]  private Vector3 cubePos;

        [SerializeField] private GameObject mainCube ;



    private void Start()
    {
        orignalCamPos = Camera.main.transform.position;


        rb = GetComponent<Rigidbody2D>();
        player_positionY = -3.2853f;

        transform.position = new Vector2(0, player_positionY);  // should spawn from starting Position

        AudioManager_Script.instance.Play("theme");


        mainCube = this.gameObject;

    }
    //reading value of input by canvas button
    void Update()
    {
        //////// Only for Computer Builds
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            leftMove();
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rightMove();
        }
        

        // check if slider.value is changed
        // if (slider.GetComponent<UnityEngine.UI.Slider>().value != 0.5f)
        //     {
        //         Debug.Log("Slider Value: " + slider.GetComponent<UnityEngine.UI.Slider>().value);
        //         transform.position = new Vector2(slider.GetComponent<UnityEngine.UI.Slider>().value * Bound, player_positionY);
        //     }
    
    }

    public void ChangePositionOnSliderPointerDown()
    {
        // check if gomeover==false
        if (UIManager.instance.IsGameover == false)
            {
                Debug.Log("Slider Value: " + slider.GetComponent<UnityEngine.UI.Slider>().value);
                transform.position = new Vector2(slider.GetComponent<UnityEngine.UI.Slider>().value * Bound, player_positionY);
            }
    }

    void FixedUpdate()
        {
            rb.AddForce(new Vector2(horizontal_Speed * speed, 0) , ForceMode2D.Impulse  );
        }
   

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

            if(UIManager.instance.GetScore() > 0)
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
        // rb.AddForce(new Vector2(-1 * speed, 0) , ForceMode2D.Impulse  );

    }
     //right movement button UI
    public void rightMove()
    {
        rb.velocity = new Vector2(speed,0);
        // rb.AddForce(new Vector2(1 * speed, 0) , ForceMode2D.Impulse  );
    }
    void Touchinput()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == UnityEngine.TouchPhase.Moved)
            {
                // Get the swipe direction
                Vector2 swipeDirection = touch.deltaPosition.normalized;
                if (swipeDirection.x > 0)
                {
                    rightMove();
                }
                if (swipeDirection.x < 0)
                {
                    leftMove();
                }
               

            }
        }
    }



    public void horizontalMovement(int got_Speed)
        {
            Debug.Log("horizontal movement called");
            horizontal_Speed = got_Speed;
        }
    


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