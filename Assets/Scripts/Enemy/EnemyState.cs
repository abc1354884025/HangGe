using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemy;


    protected NavMeshAgent agent;

    private string animBoolName;//动画名称
    protected float stateTimer;//动画播放结束
    protected bool triggerCalled;//触发攻击
    protected bool playCalled;//动画播放结束
    protected Vector3 selectedPosition;

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;

        agent = enemy.agent;
    }

    public virtual void Enter()
    {
        Animator anim = enemy.anim;
        enemy.anim.SetBool(animBoolName, true);
        //rb = player.rb;
        triggerCalled = false;
        playCalled = false;

    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;


        // player.anim.SetFloat("yVelocity", rb.velocity.y);

        if (playCalled)
        {
            stateMachine.ChangeState(enemy.idleState);
        }

    }
    public virtual void Exit()
    {
        agent.destination = enemy.transform.position;
        enemy.anim.SetBool(animBoolName, false);
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

}
