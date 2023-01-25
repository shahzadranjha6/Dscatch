// this scipt responsiable for spawner movement 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] Diamonds;
    bool isSpawning = true;
    int DelayCount = 0;


    



    // ---- Rough vars
    int randomEaseFunction;

    // Start is called before the first frame update
    
    void Start()
    {
        MoveRight();
        StartCoroutine("SpawnDelay");
        InvokeRepeating("SpawnObject", 1, 0.2f);
    }
    public IEnumerator SpawnDelay()
    {
        // if (UIManager.instance.IsGameover)
        // {
        //     // Debug.Log("calling again");
        //     // isSpawning = false;
        //     // StopCoroutine("SpawnDelay");
        // }

        if(Random.Range(0,2) == 1)
            {
                Debug.Log("spawn delay");
                isSpawning = true;
                yield return new WaitForSeconds(Random.Range(1f, 4f));
                isSpawning = false;
                DelayCount = 0;

            }
        else
            {
                DelayCount++;
                Debug.Log("wait delay");
                if(DelayCount==2)
                {
                Debug.Log("DelayCount= 3 true");
                isSpawning = true;
                }
                yield return new WaitForSeconds(0.1f*UIManager.instance.Seconds);
            }


        
        StartCoroutine("SpawnDelay");
    }

    //--- method to spawn object
    void SpawnObject()
    {
        if (isSpawning == true)
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
                LeanTween.moveX(gameObject, 6, 2f).setEaseInBounce().setOnComplete(MoveRight2);
            }
            else if (randomEaseFunction == 2)
            {
                LeanTween.moveX(gameObject, 6, 2f).setEaseInCirc().setOnComplete(MoveRight2);
            }
            else if (randomEaseFunction == 3)
            {
                LeanTween.moveX(gameObject, 6, 2f).setEaseInCubic().setOnComplete(MoveRight2);
            }
            else if (randomEaseFunction == 4)
            {
                LeanTween.moveX(gameObject, 6, 2f).setEaseInElastic().setOnComplete(MoveRight2);
            }
            else if (randomEaseFunction == 5)
            {
                LeanTween.moveX(gameObject, 6, 2f).setEaseInExpo().setOnComplete(MoveRight2);
            }
            
        }
    void MoveRight2()
        {
            randomEaseFunction = Random.Range(1, 5);

            // give random by checking if conditions
            if (randomEaseFunction == 1)
            {
                LeanTween.moveX(gameObject, 12, 2f).setEaseInBounce().setOnComplete(MoveLeft);
            }
            else if (randomEaseFunction == 2)
            {
                LeanTween.moveX(gameObject, 12, 2f).setEaseInCirc().setOnComplete(MoveLeft);
            }
            else if (randomEaseFunction == 3)
            {
                LeanTween.moveX(gameObject, 12, 2f).setEaseInCubic().setOnComplete(MoveLeft);
            }
            else if (randomEaseFunction == 4)
            {
                LeanTween.moveX(gameObject, 12, 2f).setEaseInElastic().setOnComplete(MoveLeft);
            }
            else if (randomEaseFunction == 5)
            {
                LeanTween.moveX(gameObject, 12, 2f).setEaseInExpo().setOnComplete(MoveLeft);
            }
            
        }
    
    void MoveLeft()
        {
            randomEaseFunction = Random.Range(1, 5);

            if(randomEaseFunction == 1)
            {
                LeanTween.moveX(gameObject, -6, 2f).setEaseInBounce().setOnComplete(MoveLeft2);
            }
            else if (randomEaseFunction == 2)
            {
                LeanTween.moveX(gameObject, -6, 2f).setEaseInCirc().setOnComplete(MoveLeft2);
            }
            else if (randomEaseFunction == 3)
            {
                LeanTween.moveX(gameObject, -6, 2f).setEaseInCubic().setOnComplete(MoveLeft2);
            }
            else if (randomEaseFunction == 4)
            {
                LeanTween.moveX(gameObject, -6, 2f).setEaseInElastic().setOnComplete(MoveLeft2);
            }
            else if (randomEaseFunction == 5)
            {
                LeanTween.moveX(gameObject, -6, 2f).setEaseInExpo().setOnComplete(MoveLeft2);
            }

        }void MoveLeft2()
        {
            randomEaseFunction = Random.Range(1, 5);

            if(randomEaseFunction == 1)
            {
                LeanTween.moveX(gameObject, -12, 2f).setEaseInBounce().setOnComplete(MoveRight);
            }
            else if (randomEaseFunction == 2)
            {
                LeanTween.moveX(gameObject, -12, 2f).setEaseInCirc().setOnComplete(MoveRight);
            }
            else if (randomEaseFunction == 3)
            {
                LeanTween.moveX(gameObject, -12, 2f).setEaseInCubic().setOnComplete(MoveRight);
            }
            else if (randomEaseFunction == 4)
            {
                LeanTween.moveX(gameObject, -12, 2f).setEaseInElastic().setOnComplete(MoveRight);
            }
            else if (randomEaseFunction == 5)
            {
                LeanTween.moveX(gameObject, -12, 2f).setEaseInExpo().setOnComplete(MoveRight);
            }

        }

}
