using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class AiDeathState : AiState
{
    public AiStateId GetId()
    {
        return AiStateId.DeadState;
    }
    public void Enter(AiAgent agent)
    {
      //start
    }

    public void Exit(AiAgent agent)
    {
        //executed on state exit
    }


    public void Update(AiAgent agent)
    {
        //update
        agent.transform.position = new Vector3(3, 3, 3);   //agent = the enemy     
    }

    public void OnTriggerEnter(AiAgent agent)
    {
    }

    public void OnCollisionEnter(AiAgent agent)
    {
        
    }
}
