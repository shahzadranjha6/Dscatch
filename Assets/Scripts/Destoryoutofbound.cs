//this scipt responsiable for Destory Diamond fall down below
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoryoutofbound : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BlackToken")|| collision.CompareTag("RedToken"))
        {
            collision.gameObject.SetActive(false);
            
        }
    }
}
