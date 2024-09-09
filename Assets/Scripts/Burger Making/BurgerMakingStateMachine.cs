using UnityEngine;
using testAbdrahmanov.StateMachine;
using testAbdrahmanov.Visuals.Props;
using testAbdrahmanov.Envieronment;

namespace testAbdrahmanov.BurgerMaking
{
    public class BurgerMakingStateMachine : StateMachineBase
    {
        [SerializeField] private LoadingActionZone _burgerMakingZone;
        [SerializeField] private InstantActionZone _deliveryZone;
        [SerializeField] private PlayerBurgerVisuals _playerBurger;

        protected override void InitBehaviours()
        {
            base.InitBehaviours();
            _behavioursMap[typeof(BurgerNotMadeBehaviour)] = new BurgerNotMadeBehaviour(_burgerMakingZone);
            _behavioursMap[typeof(BurgerMadeBehaviour)] = new BurgerMadeBehaviour(_deliveryZone, _playerBurger);
        }

        protected override void SetBehaviourByDefault()
        {
            SetBurgerNotMadeBehaviour();
        }

        private void SetBurgerMadeBehaviour()
        {
            var behaviour = GetBehaviour<BurgerMadeBehaviour>();
            SetBehaviour(behaviour);
        }

        private void SetBurgerNotMadeBehaviour()
        {
            var behaviour = GetBehaviour<BurgerNotMadeBehaviour>();
            SetBehaviour(behaviour);
        }

        protected override void Subscribe()
        {
            _burgerMakingZone.Finished += SetBurgerMadeBehaviour;
            _deliveryZone.Done += SetBurgerNotMadeBehaviour;
        }

        protected override void Unsubscribe()
        {
            _burgerMakingZone.Finished -= SetBurgerMadeBehaviour;
            _deliveryZone.Done -= SetBurgerNotMadeBehaviour;
        }
    }
}
