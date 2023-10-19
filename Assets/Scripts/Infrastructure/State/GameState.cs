using TDS.Game.Player;
using TDS.Infrastructure.Locator;
using TDS.Services.Coroutine;
using TDS.Services.Gameplay;
using TDS.Services.Input;
using TDS.Services.LevelManagement;
using TDS.Services.Mission;
using TDS.Utility;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class GameState : AppState
    {
        #region Variables

        private PlayerMovement _playerMovement;

        #endregion

        #region Setup/Teardown

        public GameState(ServiceLocator serviceLocator) : base(serviceLocator) { }

        #endregion

        #region Public methods

        public override void Enter()
        {
            LevelManagementService levelManagementService = ServiceLocator.Get<LevelManagementService>();
            levelManagementService.Initialize(); // TODO: Nikita maybe move it to bootstrap state
            levelManagementService.LoadCurrentLevel();

            ServiceLocator.Get<CoroutineRunner>().StartFrameTimer(1, InitAfterLoadScene);
        }

        public override void Exit()
        {
            _playerMovement.Dispose();

            ServiceLocator.Get<MissionGameService>().Dispose();
            ServiceLocator.Get<GameplayService>().Dispose();
            ServiceLocator.Get<IInputService>().Dispose();
        }

        #endregion

        #region Private methods

        private void InitAfterLoadScene()
        {
            ServiceLocator.Get<MissionGameService>().Initialize();
            ServiceLocator.Get<GameplayService>().Initialize();

            _playerMovement = Object.FindObjectOfType<PlayerMovement>();
            Transform playerMovementTransform = _playerMovement.transform;

            IInputService inputService = ServiceLocator.Get<IInputService>();
            inputService.Initialize(Camera.main, playerMovementTransform);

            PlayerAttack playerAttack = _playerMovement.GetComponent<PlayerAttack>();
            
            _playerMovement.Construct(inputService);
            playerAttack.Construct(inputService);
        }

        #endregion
    }
}