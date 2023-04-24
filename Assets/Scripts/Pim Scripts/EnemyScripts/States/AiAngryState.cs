using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiAngryState : AiState
{
    public float hp = 1;
    public AiStateId GetId()
    {
        return AiStateId.AngryState;
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
        if(hp <= 0)
        {
            die(agent);
        }

    }
    public void OnTriggerEnter()
    {
        Debug.Log(";oajfh;aldjha'dlgjha'sdgjha ;oguhad fk");
        hp -= 1;
    }
    void die(AiAgent agent)
    {
        AiDeathState deathState = agent.statemachine.GetState(AiStateId.DeadState) as AiDeathState;
        agent.statemachine.ChangeState(AiStateId.DeadState);
    }

    public void OnCollisionEnter(AiAgent agent)
    {
       
    }
}
