using UnityEngine;

namespace archero
{
    public class GameState : MonoBehaviour
    {
        protected GameStateManager _gameStateManager;
        private bool _wasSet;

        public virtual void Init(GameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        public virtual void Enter()
        {
            if (_wasSet == false)
            {
                EnterFirstTime();
                _wasSet = true;
            }
        }

        public virtual void EnterFirstTime()
        {
            _wasSet = true;
        }

        public virtual void Exit()
        {

        }
    }
}
