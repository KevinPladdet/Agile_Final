using JetBrains.Annotations;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class IdleState : AiState
{
    private DetectionPlayer detectionPlayer;
    private CustomEnemyIdleMovement IdleMovement;
    private Damage damage;

    public AiStateId GetId()
    {
        return AiStateId.IdleState;
    }
    public void Enter(AiAgent agent)
    {
        if (detectionPlayer == null)
        {
            detectionPlayer = agent.GetComponent<DetectionPlayer>();        //start function(when ai enters the state)
            IdleMovement = agent.GetComponent<CustomEnemyIdleMovement>();
            damage = agent.GetComponent<Damage>();
            IdleMovement.enabled = true;
        }
    }

    public void Exit(AiAgent agent)
    {
        IdleMovement.enabled = false;
        //gets executed when ai leaves this state
    }

    public void Update(AiAgent agent)
    {

        if (detectionPlayer.seenPlayer == true)
        {
            Debug.Log("switchToangry");
            AiAngryState angryState = agent.statemachine.GetState(AiStateId.AngryState) as AiAngryState;
            agent.statemachine.ChangeState(AiStateId.AngryState);
        }
        if(damage.health <= 0)
        {
            IdleMovement.enabled = false;
            Debug.Log("SwitchToDead");
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
