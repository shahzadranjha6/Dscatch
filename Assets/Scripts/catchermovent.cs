using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class catchermovent : MonoBehaviour
{
    // Start is called before the first frame update
    private int Bound = 10;
    float horizotal;
    int speed = 15;
    AudioSource audioSource;
    public AudioClip point;
    public TextMeshProUGUI Score;
    int ScoreCount;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ScoreCount = 0;
        Score.text = "Score:" + ScoreCount;

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
            ScoreCount++;
            Score.text = "Score:" + ScoreCount;
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(point);
            Debug.Log("collected");
        }
    }
}