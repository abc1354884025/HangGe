using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    public EnemyMoveState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void AnimationFinishPlay()
    {
        base.AnimationFinishPlay();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void Enter()
    {
        base.Enter();
        enemy.agent.speed = enemy.moveSpeed;
        enemy.agent.isStopped = false;
    }

    public override void Exit()
    {
        base.Exit();
        enemy.agent.speed = 0; 
        enemy.agent.isStopped = true;
    }

    public override void Update()
    {
        base.Update();
        if (enemy.target == null)
        {
            enemy.stateMachine.ChangeState(enemy.idleState);
            return;
        }
        enemy.agent.destination=enemy.target.position;
        if (Vector3.Distance(enemy.transform.position, enemy.target.position) <= enemy.attackRange)
        {
            enemy.stateMachine.ChangeState(enemy.slashState);
        }
    }
}
