using UnityEngine;

namespace archero
{
    public class GameStateManager : MonoBehaviour
    {
        private GameState _curerentGameState;

        [SerializeField] private GameState _menuState;
        [SerializeField] private GameState _actionState;
        [SerializeField] private GameState _pauseState;
        [SerializeField] private GameState _winState;
        [SerializeField] private GameState _loseState;
        [SerializeField] private GameState _cardState;

        public void Init()
        {
            _menuState?.Init(this);
            _actionState?.Init(this);
            _pauseState?.Init(this);
            _winState?.Init(this);
            _loseState?.Init(this);
            _cardState?.Init(this);

            SetGameState(_menuState);
        }

        private void SetGameState(GameState gameState)
        {
            if (_curerentGameState)
            {
                _curerentGameState.Exit();
            }
            _curerentGameState = gameState;
            gameState.Enter();

            Debug.Log(_curerentGameState.name);
        }

        public void SetMenu()
        {
            SetGameState(_menuState);
        }

        public void SetAction()
        {
            SetGameState(_actionState);
        }

        public void SetPause()
        {
            SetGameState(_pauseState);
        }

        public void SetWint()
        {
            SetGameState(_winState);
        }

        public void SetLose()
        {
            SetGameState(_loseState);
        }

        public void SetCardState()
        {
            SetGameState(_cardState);
        }

    }
}
