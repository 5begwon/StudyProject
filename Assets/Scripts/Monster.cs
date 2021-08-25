using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // �� Ÿ��
    public enum MonsterType
    {
        None,
        ONE,
        TWO,
        THREE,
    };

    // �ʱ�ȭ
    public MonsterType type = MonsterType.None;

    // �� Ÿ�� ����
    public void SetType(MonsterType type)
    {
        this.type = type;
    }

    public float speed = 0.0f;
}

public abstract class MonsterBuilder
{
    // ������ ��
    protected Monster monster;

    // �� ����
    public Monster CreateMonster()
    {
        return monster;
    }

    // ���ο� �� ����� ����
    public void ReadyNewMonster()
    {
        monster = new Monster();
    }

    // �� ���� �� �� ����
    public abstract void SetOption();
}

// ù ��° ��
public class OneMonsterBuilder : MonsterBuilder
{
    public override void SetOption()
    {
        monster.SetType(Monster.MonsterType.ONE);
        monster.speed = 50.0f;
    }
}

public class TwoMonsterBuilder : MonsterBuilder
{
    public override void SetOption()
    {
        monster.SetType(Monster.MonsterType.TWO);
        monster.speed = 100.0f;    
    }
}

public class ThreeMonsterBuilder : MonsterBuilder
{
    public override void SetOption()
    {
        monster.SetType(Monster.MonsterType.THREE);
        monster.speed = 150.0f;
    }
}
