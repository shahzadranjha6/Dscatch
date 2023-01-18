// --- This script will have the core game mechanics

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Diamonds;


    int Bound = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", 1, 2);
    }

        //--- method to spawn object
    void SpawnObject()
    {
        Vector2 spawnpos = new Vector2(Random.Range(-Bound, Bound), transform.position.y);
        int RandomIndex = Random.Range(0, Diamonds.Length);

        float RandomScale = Random.Range(0.5f, 1.5f);
        
       Instantiate(Diamonds[RandomIndex], spawnpos, Quaternion.Euler(0,0,Random.Range(-180,180)) , this.transform).transform.localScale = new Vector3(RandomScale, RandomScale, 0.5f);
    }


}
