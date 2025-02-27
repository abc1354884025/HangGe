using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public override void DecreaseHealth(float amount)
    {
        base.DecreaseHealth(amount);
    }

    public override void DoDamage(CharacterStats target)
    {
        base.DoDamage(target);
    }

    public override void DoMagicDamage(CharacterStats target)
    {
        base.DoMagicDamage(target);
    }

    public override void IncreaseHealth(float amount)
    {
        base.IncreaseHealth(amount);
    }

    protected override void Start()
    {
        base.Start();
    }
}
