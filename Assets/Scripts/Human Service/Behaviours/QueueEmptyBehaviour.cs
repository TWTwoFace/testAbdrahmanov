using testAbdrahmanov.Envieronment;
using Behaviour = testAbdrahmanov.StateMachine.Behaviour;

namespace testAbdrahmanov.HumanService
{
    public class QueueEmptyBehaviour : Behaviour
    {
        private LoadingActionZone _serviceZone;

        public QueueEmptyBehaviour(LoadingActionZone serviceZone)
        {
            _serviceZone = serviceZone;
        }

        public override void Enter()
        {
            _serviceZone.gameObject.SetActive(false);
        }
    }
}

