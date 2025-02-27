using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpinningState : PlayerState
{

    public PlayerSpinningState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }



    public override void Enter()
    {
        base.Enter();
        triggerCalled=true;
        agent.isStopped = false;
        
    }

    public override void Exit()
    {
        base.Exit();
        agent.isStopped = true;
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.E))
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    /// <summary>
    /// 重写移动方法，能移动但不切换到其他状态
    /// </summary>
    public override void ClickMove()
    {
        if (Input.GetMouseButtonDown(1))
        {
            agent.destination = player.destination;
        }
    }
}
