using System;
using testAbdrahmanov.Movement.Human;
using UnityEngine;

namespace testAbdrahmanov.Envieronment.Triggers
{
    public class HumanTrigger : MonoBehaviour
    {
        public event Action HumanCame;
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<HumanMovement>(out var human))
            {
                HumanCame?.Invoke();
            }
        }
    }
}

