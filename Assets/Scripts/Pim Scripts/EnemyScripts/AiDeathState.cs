using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}
