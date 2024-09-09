using testAbdrahmanov.Envieronment;
using UnityEngine;
using Behaviour = testAbdrahmanov.StateMachine.Behaviour;


namespace testAbdrahmanov.BurgerMaking
{
    public class BurgerNotMadeBehaviour : Behaviour
    {
        private LoadingActionZone _makingBurgerZone;

        public BurgerNotMadeBehaviour(LoadingActionZone makingBurgerZone)
        {
            _makingBurgerZone = makingBurgerZone;
        }

        public override void Enter()
        {
            _makingBurgerZone.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            _makingBurgerZone.gameObject.SetActive(false);
        }
    }
}

