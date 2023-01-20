using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDown : MonoBehaviour
{
    public float speed = 2f;
    float y = 0;
    private void Start()
    {
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector2(transform.position.x,(y-speed));
    }
}
