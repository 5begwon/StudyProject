using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몹 빌더를 사용 디렉터
public class MonsterDirector : MonoBehaviour
{
    // 몹 타입을 담을 변수
    private MonsterBuilder monsterBuilder;

    // 몹 타입 세팅 변수
    public void SetMonsterBuilder(MonsterBuilder builder)
    {
        monsterBuilder = builder;
    }

    // 몹 생성 설정
    public void CreateMonster()
    {
        monsterBuilder.ReadyNewMonster();
        monsterBuilder.SetOption();
    }

    // 몹 생성
    public Monster GetMonster()
    {
        return monsterBuilder.CreateMonster();
    }
}