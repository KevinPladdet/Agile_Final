using Pathfinding;
using Pathfinding.Examples;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class AiAngryState : AiState
{
    private Damage damage;
    private AIDestinationSetter follow;
    private AIPath aipath;
    private EnemyRemember enemyRemember;
    private EnemyAttack enemyAttack;

    public AiStateId GetId()
    {
        return AiStateId.AngryState;
    }
    public void Enter(AiAgent agent)
    {
        follow = agent.GetComponent<AIDestinationSetter>();
        damage = agent.GetComponent<Damage>();
        aipath = agent.GetComponent<AIPath>();
        enemyRemember = agent.GetComponent<EnemyRemember>();
        enemyAttack = agent.GetComponent<EnemyAttack>();
        follow.enabled = true; 
        enemyRemember.enabled = true;
        enemyAttack.enabled = true;
        
        aipath.maxSpeed = 5; 
        //start function(when ai enters the state)

    }

    public void Exit(AiAgent agent)
    {
        //gets executed when ai leaves this state
        follow.enabled = false;
        enemyRemember.enabled = false;
        enemyAttack.enabled = false;
    }

    public void Update(AiAgent agent)
    {
        if (damage.health <= 0)
        {
            Debug.Log("SwitchToDead");
            AiDeathState deathState = agent.statemachine.GetState(AiStateId.DeadState) as AiDeathState;
            agent.statemachine.ChangeState(AiStateId.DeadState);
        }
        if(enemyRemember.forgor == true)
        {
            Debug.Log("switchToIdle");
            IdleState idlestate = agent.statemachine.GetState(AiStateId.IdleState) as IdleState;
            agent.statemachine.ChangeState(AiStateId.IdleState);
        }
    }
    public void OnTriggerEnter(AiAgent agent)
    {

    }

    public void OnCollisionEnter(AiAgent agent)
    {
    }
}
