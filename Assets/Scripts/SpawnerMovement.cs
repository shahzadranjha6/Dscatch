// this scipt responsiable for spawner movement 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] Diamonds;
    bool isSpawning = true;


    



    // ---- Rough vars
    int randomEaseFunction;

    // Start is called before the first frame update
    
    void Start()
    {
        
        MoveRight();
        InvokeRepeating("SpawnObject", 1, 0.2f);
        StartCoroutine("SpawnDelay");
    }
    IEnumerable SpawnDelay()
    {
        isSpawning = true;
        yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        isSpawning = false;
        StartCoroutine("SpawnDelay");


    }

    //--- method to spawn object
    void SpawnObject()
    {
        if (isSpawning)
        {

            int RandomIndex = Random.Range(0, Diamonds.Length);

            float RandomScale = Random.Range(0.5f, 1.5f);
            ObjectPooler.instance.SpawnfromPool(Diamonds[RandomIndex], transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180))).transform.localScale = new Vector3(RandomScale, RandomScale, 0.5f);
        }
    
       
    }

    void MoveRight()
        {
            randomEaseFunction = Random.Range(1, 5);

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
            randomEaseFunction = Random.Range(1, 5);

            if(randomEaseFunction == 1)
            {
                LeanTween.moveX(gameObject, -12, 4f).setEaseInBounce().setOnComplete(MoveRight);
            }
            else if (randomEaseFunction == 2)
            {
                LeanTween.moveX(gameObject, -12, 4f).setEaseInCirc().setOnComplete(MoveRight);
            }
            else if (randomEaseFunction == 3)
            {
                LeanTween.moveX(gameObject, -12, 4f).setEaseInCubic().setOnComplete(MoveRight);
            }
            else if (randomEaseFunction == 4)
            {
                LeanTween.moveX(gameObject, -12, 4f).setEaseInElastic().setOnComplete(MoveRight);
            }
            else if (randomEaseFunction == 5)
            {
                LeanTween.moveX(gameObject, -12, 4f).setEaseInExpo().setOnComplete(MoveRight);
            }

        }

}
