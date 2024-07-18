using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int poolSize = 10;

    private List<GameObject> pool;

    void Awake()
    {
        pool = new List<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            DontDestroyOnLoad(obj);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeSelf)
            {
                return obj;
            }
        }

        // 如果池中没有可用的对象，根据需要可以决定扩展池
        GameObject newObj = Instantiate(prefab);
        DontDestroyOnLoad(newObj);
        newObj.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }

    public void ReturnPooledObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}