using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class IdleState : AiState
{
    private DetectionPlayer detectionPlayer;

    public AiStateId GetId()
    {
        return AiStateId.IdleState;
    }
    public void Enter(AiAgent agent)
    {
        if (agent.GetComponent<DetectionPlayer>()!= null)
        {
            detectionPlayer = agent.GetComponent<DetectionPlayer>();
        }
        //start function(when ai enters the state)
    }

    public void Exit(AiAgent agent)
    {
        //gets executed when ai leaves this state
    }

    public void Update(AiAgent agent)
    {
     if (detectionPlayer.seenPlayer == true)
        {
            AiDeathState deathState = agent.statemachine.GetState(AiStateId.DeadState) as AiDeathState;
            agent.statemachine.ChangeState(AiStateId.DeadState);
        }
    }

    public void OnTriggerEnter(AiAgent agent)
    {
    }

    public void OnCollisionEnter(AiAgent agent)
    {
    }
}
