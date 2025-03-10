using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerStateMachine
{
    public PlayerState currentState { get; private set; }



    public void Initialize(PlayerState startState)
    {
        currentState = startState;
        currentState.Enter();
    }
    public void ChangeState(PlayerState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
