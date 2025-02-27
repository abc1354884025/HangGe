using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EquipType
{
    Head,
    Chest,
    Hands,
    Legs,
    Feet,
    Weapon,
}

[System.Serializable]
public class ItemData_Equipment : ItemData
{
    
    public string name;
    public string sprite;
    public EquipType equipType;
    public float health;
    public float mana;
    public float healthRegen;
    public float manaRegen;
    public float attackDamage;
    public float physicalPenetration;
    public float magicPenetration;
    public float abilityPower;
    public float spellPenetration;

    public float physicalResistance;
    public float magicResistance;

    public float critChance;
    public float critDamage;

    public float moveSpeed;

    public void AddModifier(PlayerStats playerStats)
    {
        playerStats.maxHealth.AddModifier(health);
        playerStats.maxMana.AddModifier(mana);
        playerStats.healthRegen.AddModifier(healthRegen);
        playerStats.manaRegen.AddModifier(manaRegen);
        playerStats.attackDamage.AddModifier(attackDamage);
        playerStats.physicalPenetration.AddModifier(physicalPenetration);
        playerStats.spellPenetration.AddModifier(spellPenetration);
        playerStats.abilityPower.AddModifier(abilityPower);
        playerStats.spellPenetration.AddModifier(spellPenetration);
        playerStats.physicalResistance.AddModifier(physicalResistance);
        playerStats.magicResistance.AddModifier(magicResistance);
        playerStats.critChance.AddModifier(critChance);
        playerStats.critDamage.AddModifier(critDamage);
        playerStats.moveSpeed.AddModifier(moveSpeed);

    }
    public void RemoveModifier(PlayerStats playerStats)
    {
        playerStats.maxHealth.RemoveModifier(health);
        playerStats.maxMana.RemoveModifier(mana);
        playerStats.healthRegen.RemoveModifier(healthRegen);            
        playerStats.manaRegen.RemoveModifier(manaRegen);
        playerStats.attackDamage.RemoveModifier(attackDamage);
        playerStats.physicalPenetration.RemoveModifier(physicalPenetration);
        playerStats.spellPenetration.RemoveModifier(spellPenetration);
        playerStats.abilityPower.RemoveModifier(abilityPower);
        playerStats.spellPenetration.RemoveModifier(spellPenetration);
        playerStats.physicalResistance.RemoveModifier(physicalResistance);
        playerStats.magicResistance.RemoveModifier(magicResistance);
        playerStats.critChance.RemoveModifier(critChance);
        playerStats.critDamage.RemoveModifier(critDamage);
        playerStats.moveSpeed.RemoveModifier(moveSpeed);
    }
}
