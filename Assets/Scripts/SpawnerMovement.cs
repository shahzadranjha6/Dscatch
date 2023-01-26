// this scipt responsiable for spawner movement and spawning objects
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    public static SpawnerMovement instance;

    public string[] Diamonds;
    bool isSpawning = true;
    int DelayCount = 0;
    public float delay_frequencyBlackToken = 0.7f;
    public float delay_frequencyRedToken = 0f;



    // ---- Rough vars
    int randomEaseFunction;
    ObjectPooler objectPooler;
    int RandomIndex;
    float RandomScale;


    void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }



    void Start()
    {
        objectPooler = ObjectPooler.instance;

        MoveRight();
        StartCoroutine("SpawnDelay");

        // InvokeRepeating("SpawnBlackToken", 1, 0.2f);

        StartCoroutine("SpawnBlackToken");
        StartCoroutine("SpawnRedToken");

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
                
                yield return new WaitForSeconds(3);
            }

        StartCoroutine("SpawnDelay");
    }





    //--- method to spawn object
    IEnumerator SpawnBlackToken()
    {
        if (isSpawning == true)
        {
            

            RandomScale = Random.Range(0.5f, 1.5f);
            objectPooler.SpawnfromPool(Diamonds[0], transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180))).transform.localScale = new Vector3(RandomScale, RandomScale, 0.5f);
        }

        //--- larger the frequency, smaller the wait time

        // DelayFrequency -= .05f;

        Debug.Log("DelayFrequency: " + delay_frequencyBlackToken);
        
        yield return new WaitForSeconds(delay_frequencyBlackToken);

        StartCoroutine("SpawnBlackToken");
    }
    IEnumerator SpawnRedToken()
    {
        if (isSpawning == true)
        {
            //RandomIndex = Random.Range(0, Diamonds.Length);

            RandomScale = Random.Range(0.5f, 1.5f);
            objectPooler.SpawnfromPool(Diamonds[1], transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180))).transform.localScale = new Vector3(RandomScale, RandomScale, 0.5f);
        }

        //--- larger the frequency, smaller the wait time

        // DelayFrequency -= .05f;

        

        yield return new WaitForSeconds(delay_frequencyRedToken);

        StartCoroutine("SpawnRedToken");
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

        }


    void MoveLeft2()
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
