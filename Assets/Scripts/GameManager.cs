using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IState
{
    void Operation();
}

public class Pattern1 : IState
{
    public void Operation()
    {

    }
}

public class Pattern2 : IState
{
    public void Operation()
    {

    }
}

public class Pause : IState
{
    public void Operation()
    {

    }
}

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

    [SerializeField]
    GameObject AddPrefab;

    public GameObject player;
    public GameObject map_prefab1;
    public GameObject map_prefab2;

    public GameObject map1_pattern_spawn;
    public GameObject map2_pattern_spawn;

    public GameObject canvas;

    public StateManager statemanager = new StateManager(new Pause());

    void Start()
    {
        ObjectPool.instance.ReleaseObj(0);
        ObjectPool.instance.ReleaseObj(1);
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
            player.transform.position = map1_pattern_spawn.transform.position;

            if (map_prefab2.activeSelf == true)
                ObjectPool.instance.ReleaseObj(1);

            canvas.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            ObjectPool.instance.GetObj(1, gameObject.transform);
            player.transform.position = map2_pattern_spawn.transform.position;

            if (map_prefab1.activeSelf == true)
                ObjectPool.instance.ReleaseObj(0);

            canvas.SetActive(false);
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            canvas.SetActive(true);
        }
    }
}
