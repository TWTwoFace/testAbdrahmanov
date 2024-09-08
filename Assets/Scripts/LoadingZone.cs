using System;
using System.Collections;
using testAbdrahmanov.Movement;
using UnityEngine;


namespace testAbdrahmanov.Invieronment
{
    public class LoadingZone : MonoBehaviour
    {
        public event Action Loaded;
        public event Action Failed;

        public float Progress => _loadingTimer / _timeToLoad; 

        [SerializeField, Min(0.1f)] private float _timeToLoad;

        private Coroutine _loadingRoutine;
        private float _loadingTimer = 0;

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
            while (_loadingTimer < _timeToLoad)
            {
                _loadingTimer += Time.deltaTime;
                yield return null;
            }
            Loaded?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            _loadingTimer = 0f;
            StopCoroutine(_loadingRoutine);
            Failed?.Invoke();
        }

        private void Update()
        {
            Debug.Log(Progress);
        }
    }
}
