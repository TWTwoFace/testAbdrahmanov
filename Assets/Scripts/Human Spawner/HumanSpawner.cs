using testAbdrahmanov.Envieronment.Queue;
using testAbdrahmanov.Movement.Human;
using UnityEngine;

namespace testAbdrahmanov.Envieronment.Spawner
{
    public class HumanSpawner : MonoBehaviour
    {
        [SerializeField] private HumanMovement _humanPrefab;
        [SerializeField] private QueueController _queueController;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField, Min(1f)] private float _timeToSpawn;

        private float _spawnTimer = 0f;

        private void Spawn()
        {
            Transform moveToPoint;
            moveToPoint = _queueController.TryGetFirstEmptyPoint();
            if (moveToPoint == null)
                return;

            HumanMovement human = Instantiate(_humanPrefab, _spawnPoint.position, Quaternion.identity);

            _queueController.TryAddHumanToQueue(human);

            human.MoveTo(moveToPoint.position);
        }

        private void Update()
        {
            if (_spawnTimer >= _timeToSpawn)
            {
                Spawn();
                _spawnTimer = 0f;
            }

            _spawnTimer += Time.deltaTime;
        }
    }
}

