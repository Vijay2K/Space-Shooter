using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance;

    private Dictionary<string, Queue<GameObject>> poolDict;    

    private void Awake()
    {
        instance = this;
        poolDict = new Dictionary<string, Queue<GameObject>>();
    }

    public GameObject ReleaseFromThePool(GameObject obj, Vector3 pos)
    {
        if(poolDict.TryGetValue(obj.name, out Queue<GameObject> objectQueue))
        {
            if(objectQueue.Count > 0)
            {
                GameObject releasedObj = objectQueue.Dequeue();
                releasedObj.transform.position = pos;
                releasedObj.SetActive(true);
                return releasedObj;
            }
            else
            {
                return CreateGameobject(obj, pos);
            }
        }
        else
        {
            return CreateGameobject(obj, pos);
        }
    }

    private GameObject CreateGameobject(GameObject obj, Vector3 position)
    {
        GameObject spawnedObj = Instantiate(obj);
        spawnedObj.name = obj.name;
        spawnedObj.transform.position = position;
        return spawnedObj;
    }

    public void ReturnToPool(GameObject obj)
    {
        if(poolDict.TryGetValue(obj.name, out Queue<GameObject> objectQueue))
        {
            objectQueue.Enqueue(obj);
        }
        else
        {
            Queue<GameObject> newObjectsQueue = new Queue<GameObject>();
            newObjectsQueue.Enqueue(obj);
            poolDict.Add(obj.name, newObjectsQueue);
        }

        obj.SetActive(false);
    }
}
