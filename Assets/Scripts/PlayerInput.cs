using System;
using UnityEngine;


namespace testAbdrahmanov.Input
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action JoystickDragBegined;
        public event Action JoystickDragEnded;

        [SerializeField] private Joystick _joystick;

        public Vector3 GetDirection()
        {
            Vector3 cameraForwardProjection = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
            Vector3 cameraRightProjection = new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z).normalized;
            Vector3 direction = cameraForwardProjection * _joystick.Vertical + cameraRightProjection * _joystick.Horizontal;
            return direction;
        }

        private void OnJoystickDragBegined()
        {
            JoystickDragBegined?.Invoke();
        }

        private void OnJoystickDragEnded()
        {
            JoystickDragEnded?.Invoke();
        }

        public bool isHandled()
        {
            if (_joystick.Direction == Vector2.zero)
                return false;

            return true;
        }

        private void OnEnable()
        {
            _joystick.OnDragBegin += OnJoystickDragBegined;
            _joystick.OnDragEnd += OnJoystickDragEnded;
        }

        private void OnDisable()
        {
            _joystick.OnDragBegin -= OnJoystickDragBegined;
            _joystick.OnDragEnd -= OnJoystickDragEnded;
        }
    }
}
