using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_StatSlot: MonoBehaviour
{
    private UI ui;
    [SerializeField]private StatType statType;
    [SerializeField]private TextMeshProUGUI statValueText;
    [SerializeField] private TextMeshProUGUI statNameText;


    private void OnValidate()
    {
        gameObject.name ="UI_StatSlot - " + statType.ToString();
        if (statNameText != null)
        {
            statNameText.text = statType.ToString();
        }

    }
    private void Start()
    {
        
        UpdateStatValueUI();
    }

    public void UpdateStatValueUI()
    {
        CharacterStats charStats = PlayerManager.instance.player.GetComponent<CharacterStats>();
        if(charStats!= null)
        {

            if(statType == StatType.Health)
            {
                statValueText.text = charStats.currentHealth.ToString();
            }else if(statType == StatType.Mana)
            {
                statValueText.text = charStats.currentMana.ToString();
            }else if(statType == StatType.ManaRegen){
                statValueText.text = charStats.manaRegen .ToString();
            }else if(statType == StatType.HealthRegen)
            {
                statValueText.text = charStats.healthRegen.ToString();
            }else if(statType== StatType.AttackDamage)
            {
                statValueText.text = charStats.attackDamage.ToString();
            }else if(statType == StatType.PhysicalPenetration)
            {
                statValueText.text = charStats.physicalPenetration.ToString();
            }else if(statType == StatType.AbilityPower)
            {
                statValueText.text = charStats.abilityPower.ToString();
            }else if(statType == StatType.SpellPenetration)
            {
                statValueText.text = charStats.spellPenetration.ToString();
            }
            else if(statType == StatType.MagicResistance)
            {
                statValueText.text = charStats.magicResistance.ToString();
            }else if(statType == StatType.PhysicalResistance)
            {
                statValueText.text = charStats.physicalResistance.ToString();
            }else if(statType == StatType.MoveSpeed)
            {
                statValueText.text = charStats.moveSpeed.ToString();
            }else if(statType == StatType.CritChance)
            {
                statValueText.text = charStats.critChance.ToString();
            }else if(statType == StatType.CritDamage)
            {
                statValueText.text = charStats.critDamage.ToString();
            }
        }
    }
}
