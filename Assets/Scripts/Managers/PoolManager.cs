using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.name = pool.tag;
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }

        Debug.Log(poolDictionary.Count + " pools created.");
    }

    public GameObject SpawnFromPool(string tag, Transform parent,Vector3 position, Quaternion rotation)
    {
        #region Checks

        if (poolDictionary == null)
        {
            return null;
        }

        
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }
        

        if (poolDictionary[tag].Count == 0)
        {
            return null;
        }

        #endregion
        

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.SetParent(parent);
        objectToSpawn.transform.localPosition = position;
        objectToSpawn.transform.localRotation = rotation;
        return objectToSpawn;
    }

    public void ReturnToPool(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        poolDictionary[objectToReturn.tag].Enqueue(objectToReturn);
    }
}
