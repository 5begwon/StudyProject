using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton���� ObjectPool
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    /// <summary>
    /// ObjectPool�� �����Ǵ� ������Ʈ
    /// </summary>
    [SerializeField]
    List<GameObject> poolObject = new List<GameObject>();

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
        DontDestroyOnLoad(this);
    }

    public GameObject GetObj(int id, Transform t)
    {
        GameObject obj = poolObject[id];

        obj.transform.parent = gameObject.transform;
        obj.transform.position = t.position;
        obj.SetActive(true);
        return obj;
    }

    public void ReleaseObj(int id)
    {
        GameObject obj = poolObject[id];
        obj.transform.parent = this.transform;
        obj.SetActive(false);
    }

    public void ReleaseObj(GameObject obj)
    {
        int index = poolObject.FindIndex(x => x == obj);
        GameObject GameObj = poolObject[index];
        obj.transform.parent = this.transform;
        obj.SetActive(false);
    }

    public void AddObject(GameObject obj)
    {
        poolObject.Add(obj);
        Instantiate(obj, gameObject.transform);
    }
}
