using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAgent : MonoBehaviour
{
    public enemyStateController statemachine;
    public AiStateId initialState;
    // Start is called before the first frame update
    void Start()
    {
        statemachine = new enemyStateController(this);
        statemachine.ChangeState(initialState);

        statemachine.RegisterState(new IdleState());

        statemachine.RegisterState(new AlertState());

        statemachine.RegisterState(new AiAngryState());

        statemachine.RegisterState(new AiDeathState());
    }

    // Update is called once per frame
    void Update()
    {
        statemachine.Update();
    }
}
