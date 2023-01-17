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

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnObject()
    {
        Vector2 spawnpos = new Vector2(Random.Range(-Bound, Bound), transform.position.y);
        int RandomIndex = Random.Range(0, Diamonds.Length);
        
    Instantiate(Diamonds[RandomIndex], spawnpos, Diamonds[RandomIndex].transform.rotation).transform.parent = transform;
    }


}
