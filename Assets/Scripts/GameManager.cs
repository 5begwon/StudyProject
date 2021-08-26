using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
    }

    [SerializeField]
    GameObject AddPrefab;

    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ObjectPool.instance.GetObj(0, gameObject.transform);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            ObjectPool.instance.GetObj(1, gameObject.transform);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            ObjectPool.instance.GetObj(2, gameObject.transform);
        }
        if(Input.GetKeyDown(KeyCode.F4))
        {
            ObjectPool.instance.GetObj(3, gameObject.transform);

        }
    }
}
