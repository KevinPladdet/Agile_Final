using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAgent : MonoBehaviour
{
    public enemyStateController statemachine;
    // Start is called before the first frame update
    void Start()
    {
        statemachine = new enemyStateController(this);

        statemachine.RegisterState(new IdleState());

        statemachine.RegisterState(new AlertState());

        statemachine.RegisterState(new AiAngryState());

        statemachine.RegisterState(new AiDeathState());

        statemachine.CurrentState = AiStateId.IdleState;
    }

    // Update is called once per frame
    void Update()
    {
        statemachine.Update();
    }
}
