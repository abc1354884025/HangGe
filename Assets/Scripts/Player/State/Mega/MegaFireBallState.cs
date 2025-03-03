using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaFireBallState : PlayerState
{
    
    public MegaFireBallState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        skillName = SkillName.fireball;
        anticipation = SaveManager.instance.skillDataDic[(int)skillName].anticipation;
    }

    public override void AnimationFinishPlay()
    {
        base.AnimationFinishPlay();
        
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        SkillManager.instance.fireBall.UseSkill();
    }

    public override void ClickMove()
    {
        base.ClickMove();
    }

    public override void Enter()
    {
        base.Enter();
        player.anim.SetBool("CastCompleted", false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (anticipation < 0)
        {
            player.anim.SetBool("CastCompleted", true);
        }
        else
        {
            anticipation -= Time.deltaTime;
        }
    }
}
