using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // 各 鸥涝
    public enum MonsterType
    {
        None,
        ONE,
        TWO,
        THREE,
    };

    // 檬扁拳
    public MonsterType type = MonsterType.None;

    // 各 鸥涝 悸泼
    public void SetType(MonsterType type)
    {
        this.type = type;
    }

    public float speed = 0.0f;
}

public abstract class MonsterBuilder
{
    // 积己瞪 各
    protected Monster monster;

    // 各 府畔
    public Monster CreateMonster()
    {
        return monster;
    }

    // 货肺款 各 父靛绰 苞沥
    public void ReadyNewMonster()
    {
        monster = new Monster();
    }

    // 各 积己 傈 各 悸泼
    public abstract void SetOption();
}

// 霉 锅掳 各
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
