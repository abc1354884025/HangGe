using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("��ǰ����ֵ")][SerializeField] public float currentHealth;//��ǰ����ֵ
    [Header("��ǰħ��ֵ")][SerializeField] public float currentMana;//��ǰħ��ֵ
    [Header("����ֵ")][SerializeField] public Stat maxHealth;//����ֵ
    
    [Header("ħ��ֵ")][SerializeField] public  Stat maxMana;//ħ��ֵ
    
    [Header("�����ָ�")][SerializeField] public Stat healthRegen;//�����ָ�
    [Header("ħ���ָ�")][SerializeField] public Stat manaRegen;//ħ���ָ�
    [Header("�﹥")][SerializeField] public Stat attackDamage;//�﹥
    [Header("�ﴩ")][SerializeField] public Stat physicalPenetration;//�ﴩ
    [Header("����")][SerializeField] public Stat abilityPower;//��ǿ
    [Header("����")][SerializeField] public Stat spellPenetration;//����

    [Header("�￹")][SerializeField] public Stat physicalResistance;//�￹
    [Header("ħ��")][SerializeField] public Stat magicResistance;//ħ��

    [Header("������")][SerializeField] public Stat critChance;//������
    [Header("�����˺�")][SerializeField] public Stat critDamage;//�����˺�
    [Header("�ƶ��ٶ�")][SerializeField] public Stat moveSpeed;//�ƶ��ٶ�

    [Header("����")][SerializeField] public Stat Shield;//����

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

    //��Ѫ
    public virtual void IncreaseHealth(float amount)
    {
        currentHealth += amount;
        if(currentHealth > maxHealth.GetValue())
        {
            currentHealth = maxHealth.GetValue();
        }
        onHealthChange?.Invoke();
    }
    //��Ѫ
    public virtual void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        onHealthChange?.Invoke();
 
    }
    //�����ж�
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
