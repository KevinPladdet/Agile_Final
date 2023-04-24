using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonobehaviourTriggers : MonoBehaviour
{
    public AiState aiState;

    private void OnTriggerEnter(Collider other)
    {
        // Call the OnTriggerEnter method in the AiAngryState instance
        aiState.OnTriggerEnter();
    }

}
