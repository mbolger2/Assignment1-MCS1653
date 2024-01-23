using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ConveyorAnim : MonoBehaviour
{
    [Header("Object Pooling")]
    public static ConveyorAnim SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public GameObject spawnPoint;
    public int amountToPool;

  
    float spawnTime = 0.0f;


    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    void Update()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime >= 3f)
        {
            GameObject barrel = ConveyorAnim.SharedInstance.GetPooledObject();
            if (barrel != null)
            {
                barrel.transform.position = spawnPoint.transform.position;
                barrel.SetActive(true);
            }

            spawnTime = 0.0f;
        }
    }
}
