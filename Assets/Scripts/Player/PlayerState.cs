using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerState
{


    protected PlayerStateMachine stateMachine;
    protected Player player;

    protected NavMeshAgent agent;

    protected SkillName skillName;//����� ��ǰ״̬�ͷŵļ���

    private string animBoolName;//��������
    protected float stateTimer;//�������Ž���
    protected bool triggerCalled;//��������
    protected bool playCalled;//�������Ž���
    protected Vector3 selectedPosition;
    protected float anticipation;//����ǰҡ
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
    /// �������
    /// </summary>
    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
    /// <summary>
    /// �������Ž���
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
