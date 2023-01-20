using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MoveRight();
    }

    void MoveRight()
        {
            LeanTween.moveX(gameObject, 12, 4f).setOnComplete(MoveLeft);
        }
    
    void MoveLeft()
        {
            LeanTween.moveX(gameObject, -12, 4f).setOnComplete(MoveRight);
        }

}
