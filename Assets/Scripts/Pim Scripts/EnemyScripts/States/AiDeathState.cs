using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class AiDeathState : AiState
{
    public RagdollToggle ragdoll;
    public BoxCollider boxcollider;

    public AiStateId GetId()
    {
        return AiStateId.DeadState;
    }
    public void Enter(AiAgent agent)
    {
        ragdoll = agent.GetComponent<RagdollToggle>();
        boxcollider = agent.GetComponent<BoxCollider>();
        ragdoll.SetKinematic(false);
        boxcollider.enabled = false;
    }

    public void Exit(AiAgent agent)
    {
        //executed on state exit
    }


    public void Update(AiAgent agent)
    {

        //update
    }

    public void OnTriggerEnter(AiAgent agent)
    {
    }

    public void OnCollisionEnter(AiAgent agent)
    {
        
    }
}
