using UnityEngine;

public class MonobehaviourTriggers : MonoBehaviour
{
    public AiAgent aiAgent;

    private void OnCollisionEnter(Collision collision)
    {
        aiAgent?.statemachine?.OnCollisionEnter(collision);
    }
    private void OnTriggerEnter(Collider other)
    {
        aiAgent?.statemachine?.OnTriggerEnter(other);
    }
}