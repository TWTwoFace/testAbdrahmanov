using testAbdrahmanov.Envieronment;
using Behaviour = testAbdrahmanov.StateMachine.Behaviour;

namespace testAbdrahmanov.HumanService
{
    public class QueueFilledBehaviour : Behaviour
    {
        private LoadingActionZone _serviceZone;

        public QueueFilledBehaviour(LoadingActionZone serviceZone)
        {
            _serviceZone = serviceZone;
        }

        public override void Enter()
        {
            _serviceZone.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            _serviceZone.gameObject.SetActive(false);
        }
    }
}

