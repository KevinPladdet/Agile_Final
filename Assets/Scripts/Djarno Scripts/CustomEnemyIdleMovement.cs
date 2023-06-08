using UnityEngine;
using System.Collections;

namespace Pathfinding
{
    /// <summary>
    /// Sets the destination of an AI to the position of a specified object.
    /// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI, or AILerp.
    /// This component will then make the AI move towards the <see cref="target"/> set on this component.
    ///
    /// See: <see cref="Pathfinding.IAstarAI.destination"/>
    ///
    /// [Open online documentation to see images]
    /// </summary>
    [UniqueComponent(tag = "ai.destination")]
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
    public class CustomEnemyIdleMovement : VersionedMonoBehaviour
    {
        /// <summary>The object that the AI should move to</summary>
        public Transform target;
        public Transform targetB;
        private AIPath aiPath;
        private bool reachedTarget = false;

        private void Start()
        {
            aiPath = GetComponent<AIPath>();
        }

        private void Update()
        {
            if (!reachedTarget)
            {
                SetDestination(target);
            }
            else
            {
                SetDestination(targetB);
            }
        }

        private void SetDestination(Transform destination)
        {
            aiPath.destination = destination.position;
            float distanceToTarget = Vector3.Distance(transform.position, destination.position);
            if (distanceToTarget <= aiPath.endReachedDistance)
            {
                reachedTarget = !reachedTarget;
            }
        }
    }
}
