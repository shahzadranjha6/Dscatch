using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] Diamonds;
    public Material[] Materials;
   
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
        int Randommat = Random.Range(0, Materials.Length);
        Diamonds[RandomIndex].gameObject.GetComponent<MeshRenderer>().sharedMaterial = Materials[Randommat];
        Instantiate(Diamonds[RandomIndex], spawnpos, Diamonds[RandomIndex].transform.rotation);
    }
}
