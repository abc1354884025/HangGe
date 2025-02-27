using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseValue;

    [SerializeField] private List<float> modifiers;

    [SerializeField] private List<float> percentageModifier;
    public int GetValue()
    {
        int finalValue = baseValue;
        foreach (int modifier in modifiers)
        {
            finalValue += modifier;
        }
        float finalPercentageModifier = 1;
        foreach (float percentageModifier in this.percentageModifier)
        {
            finalPercentageModifier +=  percentageModifier;
        }

        return (int)(finalValue * finalPercentageModifier);
    }
    public void SetBaseValue(int value)
    {
        baseValue = value;
    }

    public void AddModifier(float modifier)
    {
        modifiers.Add(modifier);
    }
    public void AddPercentageModifier(float percentageModifier)
    {
        this.percentageModifier.Add(percentageModifier);
    }

    public void RemoveModifier(float modifier)
    {
        modifiers.Remove(modifier);
    }
    public void RemovePercentageModifier(float percentageModifier)
    {
        this.percentageModifier.Remove(percentageModifier);
    }
}
