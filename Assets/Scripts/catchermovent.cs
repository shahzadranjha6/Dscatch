using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchermovent : MonoBehaviour
{
    // Start is called before the first frame update
    private int Bound = 10;
    float horizotal;
    int speed = 15;
    AudioSource audioSource;
    public AudioClip point;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizotal = Input.GetAxis("Horizontal");
        transform.Translate(horizotal * Vector2.right* speed * Time.deltaTime);
        if (transform.position.x >= Bound)
        {
            transform.position = new Vector2(Bound, transform.position.y);

        }
        if (transform.position.x <= -Bound)
        {
            transform.position = new Vector2(-Bound, transform.position.y);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
{
        if (collision.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(point);
            Debug.Log("collected");
        }
    }
}