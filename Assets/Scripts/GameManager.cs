using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

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

    public interface IState
    {
        void Operation();
    }

    public class State1 : IState
    {
        public void Operation()
        {
            Debug.Log("State1");
        }
    }

    public class State2 : IState
    {
        public void Operation()
        {
            Debug.Log("State2");
        }
    }

    public class State3 : IState
    {
        public void Operation()
        {
            Debug.Log("State3");
        }
    }
    public class Context
    {
        private IState State { get; set; }
    
        public Context(IState State)
        {
            ///초기상태
            this.State = new State1();
        }
        
        public void Operation()
        {
            this.State.Operation();
        }
    }


    [SerializeField]
    GameObject AddPrefab;

    public GameObject map_prefab1;
    public GameObject map_prefab2;
    public GameObject map_prefab3;
    public GameObject map_prefab4;

    public GameObject canvas;

    void Start()
    {
        ObjectPool.instance.ReleaseObj(0);
        ObjectPool.instance.ReleaseObj(1);
        ObjectPool.instance.ReleaseObj(2);
        ObjectPool.instance.ReleaseObj(3);
    }

    void Update()
    {
        if (canvas.activeSelf == true)
            PlayerManager.Instance.speed = 0;
        else
            PlayerManager.Instance.speed = 15.0f;

        if (Input.GetKeyDown(KeyCode.F1))
        {
            ObjectPool.instance.GetObj(0, gameObject.transform);
            GameObject.Find("Player").transform.position = map_prefab1.transform.position;

            if (map_prefab2.activeSelf == true)
                ObjectPool.instance.ReleaseObj(1);
            if (map_prefab3.activeSelf == true)
                ObjectPool.instance.ReleaseObj(2);
            if (map_prefab4.activeSelf == true)
                ObjectPool.instance.ReleaseObj(3);

            canvas.SetActive(false);

            Debug.Log("Get Prefab 1 , Release2, 3, 4");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            ObjectPool.instance.GetObj(1, gameObject.transform);
            GameObject.Find("Player").transform.position = map_prefab2.transform.position;

            if (map_prefab1.activeSelf == true)
                ObjectPool.instance.ReleaseObj(0);
            if (map_prefab3.activeSelf == true)
                ObjectPool.instance.ReleaseObj(2);
            if (map_prefab4.activeSelf == true)
                ObjectPool.instance.ReleaseObj(3);

            canvas.SetActive(false);

            Debug.Log("Get Prefab 2 , Release1, 3, 4");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            ObjectPool.instance.GetObj(2, gameObject.transform);
            GameObject.Find("Player").transform.position = map_prefab3.transform.position;

            if (map_prefab1.activeSelf == true)
                ObjectPool.instance.ReleaseObj(0);
            if (map_prefab2.activeSelf == true)
                ObjectPool.instance.ReleaseObj(1);
            if (map_prefab4.activeSelf == true)
                ObjectPool.instance.ReleaseObj(3);

            canvas.SetActive(false);

            Debug.Log("Get Prefab 3 , Release1, 2, 4");
        }
        if(Input.GetKeyDown(KeyCode.F4))
        {
            ObjectPool.instance.GetObj(3, gameObject.transform);
            //GameObject.Find("Player").transform.position = map_prefab1.

            if (map_prefab1.activeSelf == true)
                ObjectPool.instance.ReleaseObj(0);
            if (map_prefab2.activeSelf == true)
                ObjectPool.instance.ReleaseObj(1);
            if (map_prefab3.activeSelf == true)
                ObjectPool.instance.ReleaseObj(2);

            canvas.SetActive(false);

            Debug.Log("Get Prefab 4 , Release1, 2, 3");
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            canvas.SetActive(true);
        }
    }
}
