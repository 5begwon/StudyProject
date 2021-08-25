using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton으로 ObjectPool
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    /// <summary>
    /// ObjectPool에 보관되는 오브젝트
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

    public GameObject GetObjFromPool(int id, Transform t)
    {
        GameObject obj = poolObject[id];

        obj.transform.parent = t;
        obj.transform.position = t.position;
        obj.SetActive(true);
        return obj;
    }

    public void BackObjToPool(int id)
    {
        GameObject obj = poolObject[id];
        obj.transform.parent = this.transform;
        obj.SetActive(false);
    }

    public void BackObjToPool(GameObject go)
    {
        int index = poolObject.FindIndex(x => x == go);
        GameObject obj = poolObject[index];
        obj.transform.parent = this.transform;
        obj.SetActive(false);
    }
}
