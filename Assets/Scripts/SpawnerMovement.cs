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

    // hide in inspector
    private float delay_frequencyBlackToken;
    public void setDelayFrequencyOfBlackToken(float value)
    {
        delay_frequencyBlackToken = value;
    }
    public int getDelayFrequencyOfBlackToken()
    {
        return DelayCount;
    }


    private float delay_frequencyRedToken;
    public int getDelayFrequencyOfRedToken()
    {
        return DelayCount;
    }
    public void setDelayFrequencyOfRedToken(float value)
    {
        delay_frequencyRedToken = value;
    }




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
        delay_frequencyBlackToken = 1.7f;
        delay_frequencyRedToken = 0.7f;


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
                
                yield return new WaitForSeconds(1.5f);
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
            RandomScale = Random.Range(0.5f, 1.5f);
            objectPooler.SpawnfromPool(Diamonds[1], transform.position, Quaternion.Euler(0, 0, Random.Range(-180, 180))).transform.localScale = new Vector3(RandomScale, RandomScale, 0.5f);
        }

        //--- larger the frequency, smaller the wait time

        // DelayFrequency -= .05f;

        yield return new WaitForSeconds(delay_frequencyRedToken);

        StartCoroutine("SpawnRedToken");
    }


    IEnumerator spawnTokens()
        {
            if(UIManager.instance.Seconds < 5)
                {
                    // spawn black
                    // spawn black
                    // spawn black
                    // spawn red
                }
            if(UIManager.instance.Seconds < 10)
                {
                    // spawn black
                    // spawn black
                    // spawn red
                    // spawn red
                }
            if(UIManager.instance.Seconds < 15)
                {
                    // spawn black
                    // spawn red
                    // spawn red
                }

            yield return new WaitForSeconds(0.6f);
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
