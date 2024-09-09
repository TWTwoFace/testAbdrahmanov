using System;
using System.Collections.Generic;
using testAbdrahmanov.Movement.Human;
using UnityEngine;

namespace testAbdrahmanov.Envieronment.Queue
{
    public class QueueController : MonoBehaviour
    {
        public event Action QueueIsEmpty;
        public int MaxCountHumans => _queuePoints.Count;

        [SerializeField] private List<Transform> _queuePoints;

        private Queue<HumanMovement> _queue;

        private void Awake()
        {
            _queue = new Queue<HumanMovement>();
        }

        public Transform TryGetFirstEmptyPoint()
        {
            if (_queue.Count < MaxCountHumans)
                return _queuePoints[_queue.Count];

            return null;
        }

        public HumanMovement DeleteFirstHumanFromQueue()
        {
            HumanMovement human =  _queue.Dequeue();

            if (_queue.Count == 0)
                QueueIsEmpty?.Invoke();

            return human;
        }

        public void TryAddHumanToQueue(HumanMovement human)
        {
            _queue.Enqueue(human);
        }
    }
}

