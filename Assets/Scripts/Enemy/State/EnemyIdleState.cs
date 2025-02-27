using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public EnemyIdleState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (enemy.target != null)
        {
            stateMachine.ChangeState(enemy.tauntState);
            //Debug.Log("Enemy Idle State: Target is null, change to taunt state");
        }
        else
        {
            //Debug.Log("Enemy Idle State: Target is not null, do nothing");
        }
    }
}
