using testAbdrahmanov.Movement;
using UnityEngine;

namespace testAbdrahmanov.Visuals.Animations
{
    [RequireComponent(typeof(Animator), typeof(PlayerMovement))]
    public class PlayerAnimations : MonoBehaviour
    {
        private Animator _animator;
        private PlayerMovement _playerMovement;

        private const string _walkTrigger = "Walk";
        private const string _idleTrigger = "Idle";

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void OnMoveStarted()
        {
            _animator.SetTrigger(_walkTrigger);
        }

        private void OnMoveFinished()
        {
            _animator.SetTrigger(_idleTrigger);
        }

        private void OnEnable()
        {
            _playerMovement.MoveStarted += OnMoveStarted;
            _playerMovement.MoveFinished += OnMoveFinished;
        }

        private void OnDisable()
        {
            _playerMovement.MoveStarted -= OnMoveStarted;
            _playerMovement.MoveFinished -= OnMoveFinished;
        }
    }
}
