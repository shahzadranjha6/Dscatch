// this script is reponsibable for object pooling
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;


    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public GameObject PoolParent;
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;



    // ---- Rough vars
    GameObject objSpawned;
    GameObject ObjectToSpawn;

    void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }


    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                objSpawned = Instantiate(pool.prefab);
                objSpawned.SetActive(false);
                objectpool.Enqueue(objSpawned);
                objSpawned.transform.parent = PoolParent.transform;
            }

            poolDictionary.Add(pool.tag, objectpool);
        }


    }
    public GameObject SpawnfromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with the " + tag + " does not exists");
            return null;
        }
        
        ObjectToSpawn = poolDictionary[tag].Dequeue();
        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position = position;
        ObjectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(ObjectToSpawn);
        return ObjectToSpawn;
    }



}
