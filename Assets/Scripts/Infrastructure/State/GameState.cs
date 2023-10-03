using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class GameState : IState
    {
        public void Exit()
        {
            Debug.LogError($"GameState Exit");
        }

        public void Enter()
        {
            Debug.LogError($"GameState Enter");
        }
    }
}