using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoryoutofbound : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            Destroy(collision.gameObject);
            Debug.Log("DESTORY");
        }
    }
}
