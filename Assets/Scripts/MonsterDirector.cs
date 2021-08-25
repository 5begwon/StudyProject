using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ������ ��� ����
public class MonsterDirector : MonoBehaviour
{
    // �� Ÿ���� ���� ����
    private MonsterBuilder monsterBuilder;

    // �� Ÿ�� ���� ����
    public void SetMonsterBuilder(MonsterBuilder builder)
    {
        monsterBuilder = builder;
    }

    // �� ���� ����
    public void CreateMonster()
    {
        monsterBuilder.ReadyNewMonster();
        monsterBuilder.SetOption();
    }

    // �� ����
    public Monster GetMonster()
    {
        return monsterBuilder.CreateMonster();
    }
}