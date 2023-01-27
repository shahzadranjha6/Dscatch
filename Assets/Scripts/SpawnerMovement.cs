// this scipt responsiable for spawner movement and spawning objects

using System.Collections;
using UnityEngine;
public class SpawnerMovement : MonoBehaviour
{
    public static SpawnerMovement instance;

    public string[] Diamonds;

    internal bool isSpawning = true;

    internal int DelayCount = 0;

    internal int randomEaseFunction;

    internal ObjectPooler objectPooler;

    internal int RandomIndex;

    internal float RandomScale;
    Vector2 PositionRed;
    Vector2 PositionBlack;


    internal void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    internal void Start()
    {
        //delay_frequencyBlackToken = 1.7f;
        // delay_frequencyRedToken = 0.7f;


        objectPooler = ObjectPooler.instance;

        MoveRight();
        StartCoroutine("SpawnDelay");
        StartCoroutine("spawnTokens");
    }

    public IEnumerator SpawnDelay()
    {
        // if (UIManager.instance.IsGameover)
        // {
        //     // Debug.Log("calling again");
        //     // isSpawning = false;
        //     // StopCoroutine("SpawnDelay");
        // }

        if (Random.Range(0, 2) == 1)
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

            if (DelayCount == 2)
            {
                Debug.Log("DelayCount= 3 true");
                isSpawning = true;
            }

            yield return new WaitForSeconds(1.5f);
        }

        StartCoroutine("SpawnDelay");
    }

    internal void SpawnBlackToken()
    {
        if (isSpawning == true)
        {

            PositionBlack = new Vector2(transform.position.x, transform.position.y) + new Vector2(Random.Range(-6f,6f), Random.Range(1f, 5f));
            RandomScale = Random.Range(0.5f, 1.5f);
            objectPooler.SpawnfromPool(Diamonds[0], PositionBlack, Quaternion.Euler(0, 0, Random.Range(-180, 180))).transform.localScale = new Vector3(RandomScale, RandomScale, 0.5f);
        }
    }

    internal void SpawnRedToken()
    {
        if (isSpawning == true)
        {
            PositionRed = new Vector2(transform.position.x, transform.position.y) + new Vector2(Random.Range(-6f, 6f), Random.Range(1f, 5f));
            RandomScale = Random.Range(0.5f, 1.5f);
            objectPooler.SpawnfromPool(Diamonds[1], PositionRed, Quaternion.Euler(0, 0, Random.Range(-180, 180))).transform.localScale = new Vector3(RandomScale, RandomScale, 0.5f);
        }
    }

    internal IEnumerator spawnTokens()
    {
        if (UIManager.instance.Seconds < 5)
        {
            // spawn black
            // spawn black
            // spawn black
            // spawn red
            SpawnBlackToken();
            SpawnBlackToken();
            SpawnBlackToken();
            SpawnRedToken();
        }
        if (UIManager.instance.Seconds < 10)
        {
            // spawn black
            // spawn black
            // spawn red
            // spawn red
            SpawnBlackToken();
            SpawnBlackToken();
            SpawnRedToken();
            SpawnRedToken();
        }
        if (UIManager.instance.Seconds < 21)
        {
            // spawn black
            // spawn red
            // spawn red
            SpawnBlackToken();
            SpawnRedToken();
            SpawnRedToken();
        }

        yield return new WaitForSeconds(0.6f);
        StartCoroutine("spawnTokens");
    }

    internal void MoveRight()
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

    internal void MoveRight2()
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

    internal void MoveLeft()
    {
        randomEaseFunction = Random.Range(1, 5);

        if (randomEaseFunction == 1)
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

    internal void MoveLeft2()
    {
        randomEaseFunction = Random.Range(1, 5);

        if (randomEaseFunction == 1)
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
