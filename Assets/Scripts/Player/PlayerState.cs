using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerState
{


    protected PlayerStateMachine stateMachine;
    protected Player player;

    protected NavMeshAgent agent;

    protected SkillName skillName;//如果有 当前状态释放的技能

    private string animBoolName;//动画名称
    protected float stateTimer;//动画播放结束
    protected bool triggerCalled;//触发攻击
    protected bool playCalled;//动画播放结束
    protected Vector3 selectedPosition;
    protected float anticipation;//技能前摇
    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;

        agent = player.agent;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        //rb = player.rb;
        triggerCalled = false;
        playCalled = false;

    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        if (triggerCalled)
        {
            ClickMove();
        }

        // player.anim.SetFloat("yVelocity", rb.velocity.y);

        if (playCalled)
        {
            stateMachine.ChangeState(player.IdleState);
        }

    }
    public virtual void Exit()
    {
        agent.destination = player.transform.position;
        player.anim.SetBool(animBoolName, false);
    }
    /// <summary>
    /// 攻击完成
    /// </summary>
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
    /// <summary>
    /// 动画播放结束
    /// </summary>
    public virtual void AnimationFinishPlay()
    {
        playCalled = true;
    }
    public virtual void ClickMove()
    {
        if (Input.GetMouseButtonDown(1))
        {
            player.stateMachine.ChangeState(player.MoveState);
            
        }
    }


}
