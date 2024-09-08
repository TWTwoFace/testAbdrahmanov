using UnityEngine;
using testAbdrahmanov.Input;
using System;

namespace testAbdrahmanov.Movement
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovement : MonoBehaviour
    {
        public event Action MoveStarted;
        public event Action MoveFinished;

        [SerializeField] private float _speed;

        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (!_playerInput.isHandled())
                return;

            Vector3 direction = _playerInput.GetDirection();
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
        
        private void OnInputHandleStarted()
        {
            MoveStarted?.Invoke();
        }

        private void OnInputHanleFinished()
        {
            MoveFinished?.Invoke();
        }

        private void OnEnable()
        {
            _playerInput.JoystickDragBegined += OnInputHandleStarted;
            _playerInput.JoystickDragEnded += OnInputHanleFinished;
        }

        private void OnDisable()
        {
            _playerInput.JoystickDragBegined -= OnInputHandleStarted;
            _playerInput.JoystickDragEnded -= OnInputHanleFinished;
        }
    }
}
