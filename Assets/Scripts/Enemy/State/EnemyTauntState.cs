using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTauntState : EnemyState
{
    public EnemyTauntState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
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
        if (playCalled)
        {
            enemy.stateMachine.ChangeState(enemy.moveState);
        }

    }
}
