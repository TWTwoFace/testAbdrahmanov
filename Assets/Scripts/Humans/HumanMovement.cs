using UnityEngine;
using UnityEngine.AI;

namespace testAbdrahmanov.Movement.Human
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class HumanMovement : MonoBehaviour
    {
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 position)
        {
            _agent.destination = position;
        }
        
    }
}

