using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("当前生命值")][SerializeField] public float currentHealth;//当前生命值
    [Header("当前魔法值")][SerializeField] public float currentMana;//当前魔法值
    [Header("生命值")][SerializeField] public Stat maxHealth;//生命值
    
    [Header("魔法值")][SerializeField] public  Stat maxMana;//魔法值
    
    [Header("生命恢复")][SerializeField] public Stat healthRegen;//生命恢复
    [Header("魔法恢复")][SerializeField] public Stat manaRegen;//魔法恢复
    [Header("物攻")][SerializeField] public Stat attackDamage;//物攻
    [Header("物穿")][SerializeField] public Stat physicalPenetration;//物穿
    [Header("法攻")][SerializeField] public Stat abilityPower;//法强
    [Header("法穿")][SerializeField] public Stat spellPenetration;//法穿

    [Header("物抗")][SerializeField] public Stat physicalResistance;//物抗
    [Header("魔抗")][SerializeField] public Stat magicResistance;//魔抗

    [Header("暴击率")][SerializeField] public Stat critChance;//暴击率
    [Header("暴击伤害")][SerializeField] public Stat critDamage;//暴击伤害
    [Header("移动速度")][SerializeField] public Stat moveSpeed;//移动速度

    [Header("护盾")][SerializeField] public Stat Shield;//护盾

    public delegate void OnHealthChange();
    public event OnHealthChange onHealthChange;

    public delegate void OnManaChange();
    public event OnManaChange onManaChange;
    protected virtual void Awake()
    {
        currentHealth=maxHealth.GetValue();
        currentMana=maxMana.GetValue();
    }
    protected virtual void Start()
    {
        Debug.Log("CharacterStats Start");
        onHealthChange?.Invoke();
        onManaChange?.Invoke();
    }
    // Start is called before the first frame update
    public virtual void DoDamage(CharacterStats target) 
    {
        float totalDamage = target.attackDamage.GetValue();
        if (target.CanCrit())
        {
            totalDamage *= target.critDamage.GetValue();
        }

        DecreaseHealth(totalDamage);
        
    }

    public virtual void DoMagicDamage(CharacterStats target)
    {

    }

    //加血
    public virtual void IncreaseHealth(float amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth.GetValue())
        {
            currentHealth = maxHealth.GetValue();
        }
        onHealthChange?.Invoke();
    }
    //减血
    public virtual void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        onHealthChange?.Invoke();
 
    }
    //暴击判断
    private bool CanCrit()
    {
        int totalCritCalChance = critChance.GetValue();
        return Random.Range(0, 100) < totalCritCalChance;
    }

    public float GetHealth() {return currentHealth;}
    public float GetMana() { return currentMana; }
    public float GetMaxHealth(){ return maxHealth.GetValue(); }
    public float GetMaxMana() { return maxMana.GetValue(); }
}
