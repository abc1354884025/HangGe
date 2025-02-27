using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlashState : EnemyState
{
    public EnemySlashState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (Vector3.Distance(enemy.transform.position, enemy.target.position) > enemy.attackRange)
        {
            enemy.stateMachine.ChangeState(enemy.moveState);
        }
    }
}
