using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiAngryState : AiState
{
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

    }
    public void OnTriggerEnter(AiAgent agent)
    {

    }

    public void OnCollisionEnter(AiAgent agent)
    {
    }
}
