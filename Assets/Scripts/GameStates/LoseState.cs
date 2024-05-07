using UnityEngine;

namespace archero
{
    public class LoseState : GameState
    {
        [SerializeField] private LoseWindow _loseWindow;
        public override void Enter()
        {
            base.Enter();
            _loseWindow.Show();
            Time.timeScale = 0f;
        }
    }
}
