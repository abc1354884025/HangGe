using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBallSkill : Skill
{


    protected override void Awake()
    {
        base.Awake();
        skillName = SkillName.lightningBall;
    }
    protected override void Start()
    {
        base.Start();

    }
    public override void UseSkill()
    {
        base.UseSkill();//调用父类方法


    }

}
