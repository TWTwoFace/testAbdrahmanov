using System;
using testAbdrahmanov.Movement;
using UnityEngine;

namespace testAbdrahmanov.Envieronment
{
    public class InstantActionZone : MonoBehaviour
    {
        public event Action Done;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerMovement>(out var player))
            {
                Done?.Invoke();
            }
        }
    }
}