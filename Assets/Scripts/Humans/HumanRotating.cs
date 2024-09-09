using UnityEngine;
using UnityEngine.AI;

namespace testAbdrahmanov.Movement.Human
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class HumanRotating : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private const float _speed = 100f;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (_agent.velocity == Vector3.zero)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 180f, 0), _speed * Time.deltaTime);
            }
        }
    }
}

