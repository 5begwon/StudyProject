using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

     Queue<Monster> poolingObjectQueue = new Queue<Monster>();

    void Awake()
    {
        Instance = this;
        Init(4);
    }

    private void Init(int InitCount)
    {
        for (int i = 1; i < InitCount; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    private Monster CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<Monster>(); 
        newObj.gameObject.SetActive(false); 
        newObj.transform.SetParent(transform); 
        return newObj; 
    }

    public static Monster GetObject() 
    { 
        if (Instance.poolingObjectQueue.Count > 0) 
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(Monster obj) 
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform); Instance.poolingObjectQueue.Enqueue(obj);
    }
}
