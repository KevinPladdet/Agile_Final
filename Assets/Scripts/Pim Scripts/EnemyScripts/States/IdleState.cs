using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : AiState
{
    public AiStateId GetId()
    {
        return AiStateId.IdleState;
    }
    public void Enter(AiAgent agent)
    {
        //start function(when ai enters the state)
    }

    public void Exit(AiAgent agent)
    {
        //gets executed when ai leaves this state
    }

    public void Update(AiAgent agent)
    {
        //code that ai does each frame in this state here
    }

    public void OnTriggerEnter()
    {
    }

    public void OnCollisionEnter(AiAgent agent)
    {
    }
}
