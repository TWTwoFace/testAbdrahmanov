using System;
using System.Collections;
using testAbdrahmanov.Movement;
using UnityEngine;


namespace testAbdrahmanov.Envieronment
{
    public class LoadingActionZone : MonoBehaviour
    {
        public event Action Started;
        public event Action Finished;
        public event Action Failed;

        public float Progress => _loadingTimer / _timeToLoad; 

        [SerializeField, Min(0.1f)] private float _timeToLoad;

        private Coroutine _loadingRoutine;
        private float _loadingTimer = 0;
        private bool _loading;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerMovement>(out var player))
            {
                _loadingTimer = 0f;
                _loadingRoutine = StartCoroutine(Load());
            }
        }

        private IEnumerator Load()
        {
            _loading = true;
            Started?.Invoke();

            while (_loadingTimer < _timeToLoad)
            {
                _loadingTimer += Time.deltaTime;
                yield return null;
            }

            Finished?.Invoke();
            _loading = false;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!_loading)
                return;

            _loadingTimer = 0f;
            StopCoroutine(_loadingRoutine);
            Failed?.Invoke();
        }
    }
}
