using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public GameObject player;
    public GameObject map_prefab1;
    public GameObject map_prefab2;

    public GameObject map1_pattern_spawn;
    public GameObject map2_pattern_spawn;

    public GameObject canvas;

    void Start()
    {
        ObjectPool.Instance.ReleaseObj(0);
        ObjectPool.Instance.ReleaseObj(1);
    }

    void Update()
    {
        if (canvas.activeSelf == true)
            PlayerManager.Instance.speed = 0;
        else
            PlayerManager.Instance.speed = 15.0f;

        if (Input.GetKeyDown(KeyCode.F1))
        {
            ObjectPool.Instance.GetObj(0, gameObject.transform);
            player.transform.position = map1_pattern_spawn.transform.position;

            if (map_prefab2.activeSelf == true)
                ObjectPool.Instance.ReleaseObj(1);

            canvas.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            ObjectPool.Instance.GetObj(1, gameObject.transform);
            player.transform.position = map2_pattern_spawn.transform.position;

            if (map_prefab1.activeSelf == true)
                ObjectPool.Instance.ReleaseObj(0);

            canvas.SetActive(false);
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            canvas.SetActive(true);
        }
    }
}
