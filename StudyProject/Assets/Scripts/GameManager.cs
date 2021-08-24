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

        MonsterDirector director = new MonsterDirector();

        OneMonsterBuilder oneBuilder = new OneMonsterBuilder();
        TwoMonsterBuilder twoBuilder = new TwoMonsterBuilder();
        ThreeMonsterBuilder threeBuilder = new ThreeMonsterBuilder();

    void Start()
    {
        // 몹 생성 : 1. 몹을 정함 / 2. 만들 준비를 함 / 3. 진짜 만듬
        director.SetMonsterBuilder(oneBuilder);
        director.CreateMonster();
        Monster oneMonster = director.GetMonster();

        director.SetMonsterBuilder(twoBuilder);
        director.CreateMonster();
        Monster twoMonster = director.GetMonster();

        director.SetMonsterBuilder(threeBuilder);
        director.CreateMonster();
        Monster threeMonster = director.GetMonster();
    }

    void Update()
    {
    }
}
