using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillData
{
    public int id;//技能ID
    public int job;//所属职业
    public string name;//技能名称
    public float anticipation;//技能前摇
    public string prefabName;//技能预制体名称
    public float speed;//技能移动速度


    public string description;//技能描述
    public float cooldown;//冷却时间
    public float bpd;//基础物理伤害
    public float pdb;//物理伤害加成
    public float bmd;//基础魔法伤害
    public float mdb;//魔法伤害加成
    public float manaCost;//法力消耗
    public float range;//技能范围
    
    public float duration;//技能持续时间
    public float radius;//技能影响半径
    public float angle;//技能影响角度
    public float distance;//技能影响距离
    public float height;//技能影响高度

    public float heal;//技能治疗
    public float armor;//技能护甲

}
