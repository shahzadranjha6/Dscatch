using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoryoutofbound : MonoBehaviour
{

    void Update()
    {

        //transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y<=-6)
        {
            Destroy(gameObject);
        }
    }
}
