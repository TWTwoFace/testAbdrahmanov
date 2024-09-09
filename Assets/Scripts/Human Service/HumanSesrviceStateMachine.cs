using testAbdrahmanov.Envieronment;
using testAbdrahmanov.Envieronment.Queue;
using testAbdrahmanov.Envieronment.Triggers;
using testAbdrahmanov.StateMachine;
using UnityEngine;

namespace testAbdrahmanov.HumanService
{
    public class HumanSesrviceStateMachine : StateMachineBase
    {
        [SerializeField] private QueueController _queueController; 
        [SerializeField] private HumanTrigger _trigger;
        [SerializeField] private LoadingActionZone _serviceZone;

        protected override void InitBehaviours()
        {
            base.InitBehaviours();
            _behavioursMap[typeof(QueueEmptyBehaviour)] = new QueueEmptyBehaviour(_serviceZone);
            _behavioursMap[typeof(QueueFilledBehaviour)] = new QueueFilledBehaviour(_serviceZone);
        }

        protected override void SetBehaviourByDefault()
        {
            SetQueueEmptyBehaviour();
        }

        private void SetQueueEmptyBehaviour()
        {
            var behaviour = GetBehaviour<QueueEmptyBehaviour>();
            SetBehaviour(behaviour);
        }

        private void SetQueueFilledBehaviour()
        {
            var behaviour = GetBehaviour<QueueFilledBehaviour>();
            SetBehaviour(behaviour);
        }

        protected override void Subscribe()
        {
            _trigger.HumanCame += SetQueueFilledBehaviour;
            _queueController.QueueIsEmpty += SetQueueEmptyBehaviour;
        }

        protected override void Unsubscribe()
        {
            _trigger.HumanCame -= SetQueueFilledBehaviour;
            _queueController.QueueIsEmpty -= SetQueueEmptyBehaviour;
        }
    }
}