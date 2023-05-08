using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum AiStateId
{
    IdleState,
    AlertState,
    AngryState,
    DeadState
}
public interface AiState
{
    AiStateId GetId();
    void Enter(AiAgent agent);
    void Update(AiAgent agent);
    void Exit(AiAgent agent);
    void OnCollisionEnter(AiAgent agent);
    void OnTriggerEnter(AiAgent agent);
}
