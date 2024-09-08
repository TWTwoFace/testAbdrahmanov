using testAbdrahmanov.Input;
using UnityEngine;

namespace testAbdrahmanov.Movement
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private Transform _meshTransform;

        private PlayerInput _playerInput;

        private const float _speed = 1000f;
        /*private const Quaternion _defaulRotation = {}*/

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            if (!_playerInput.isHandled())
                return;

            
            Quaternion rotation = Quaternion.LookRotation(_playerInput.GetDirection());
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _speed * Time.deltaTime);
        }
    }
}
