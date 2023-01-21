using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] Diamonds;


    int Bound = 10;

    // Start is called before the first frame update
    void Start()
    {
        MoveRight();
        InvokeRepeating("SpawnObject", 1, 0.4f);
    }

    //--- method to spawn object
    void SpawnObject()
    {
        Vector2 spawnpos = new Vector2(Random.Range(-Bound, Bound), transform.position.y);
        int RandomIndex = Random.Range(0, Diamonds.Length);

        float RandomScale = Random.Range(0.5f, 1.5f);
        ObjectPooler.instance.SpawnfromPool(Diamonds[RandomIndex],transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180))).transform.localScale = new Vector3(RandomScale, RandomScale, 0.5f);
    
       
    }

    void MoveRight()
        {
            int randomEaseFunction = Random.Range(1, 5);

            // give random by checking if conditions
            if (randomEaseFunction == 1)
            {
                LeanTween.moveX(gameObject, 12, 4f).setEaseInBounce().setOnComplete(MoveLeft);
            }
            else if (randomEaseFunction == 2)
            {
                LeanTween.moveX(gameObject, 12, 4f).setEaseInCirc().setOnComplete(MoveLeft);
            }
            else if (randomEaseFunction == 3)
            {
                LeanTween.moveX(gameObject, 12, 4f).setEaseInCubic().setOnComplete(MoveLeft);
            }
            else if (randomEaseFunction == 4)
            {
                LeanTween.moveX(gameObject, 12, 4f).setEaseInElastic().setOnComplete(MoveLeft);
            }
            else if (randomEaseFunction == 5)
            {
                LeanTween.moveX(gameObject, 12, 4f).setEaseInExpo().setOnComplete(MoveLeft);
            }
            
        }
    
    void MoveLeft()
        {
            LeanTween.moveX(gameObject, -12, 4f).setEaseInElastic().setOnComplete(MoveRight);
        }

}
