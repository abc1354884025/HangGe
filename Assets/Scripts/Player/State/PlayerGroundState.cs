using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState 
{
    public PlayerGroundState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        triggerCalled = true;

    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void Update()
    {

        base.Update();
        GetSkill();


    }
    private void GetSkill()
    {
        
        if (Input.GetKeyDown(KeyCode.A)&&player.target != null)
        {
            player.selectedTarget = player.target;
            player.stateMachine.ChangeState(player.megaFireBallState);
            
        }
        if (Input.GetKeyDown(KeyCode.E) && player.target!= null)
        {
            player.selectedTarget = player.target;
            player.stateMachine.ChangeState(player.MegaLightningBallState);
            
        }
    }
    
}
