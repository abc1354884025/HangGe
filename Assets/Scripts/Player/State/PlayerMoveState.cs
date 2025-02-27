using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        agent.isStopped = false;
        selectedPosition = player.destination;
        agent.destination = selectedPosition;
    }

    public override void Exit()
    {
        base.Exit();
        agent.isStopped = true;
    }

    public override void Update()
    {
        base.Update();
        if(Vector3.Distance(player.transform.position, selectedPosition) < 0.5f)
        {
            player.stateMachine.ChangeState(player.IdleState);
        }
    }
}
