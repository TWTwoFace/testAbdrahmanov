using testAbdrahmanov.Envieronment;
using testAbdrahmanov.Visuals.Props;
using UnityEngine;
using Behaviour = testAbdrahmanov.StateMachine.Behaviour;

namespace testAbdrahmanov.BurgerMaking
{
    public class BurgerMadeBehaviour : Behaviour
    {
        private InstantActionZone _deliveryZone;
        private PlayerBurgerVisuals _playerBurger;

        public BurgerMadeBehaviour(InstantActionZone deliveryZone, PlayerBurgerVisuals playerBurger)
        {
            _deliveryZone = deliveryZone;
            _playerBurger = playerBurger;
        }

        public override void Enter()
        {
            _deliveryZone.gameObject.SetActive(true);
            _playerBurger.Show();
        }

        public override void Exit()
        {
            _deliveryZone.gameObject.SetActive(false);
            _playerBurger.Hide();
        }
    }
}
