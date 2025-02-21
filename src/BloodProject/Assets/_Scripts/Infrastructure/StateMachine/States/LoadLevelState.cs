using _Scripts.Gameplay.Features.Weapon.Data;
using _Scripts.Gameplay.Features.Weapon.Factory;
using _Scripts.Infrastructure.Constants;
using _Scripts.Infrastructure.Services.SceneLoader;
using _Scripts.Infrastructure.Services.StaticData.Provider;
using _Scripts.Infrastructure.StateMachine.StateInfrastructure;
using Gameplay.Features.Player.Factory;

namespace _Scripts.Infrastructure.StateMachine.States
{
    public class LoadLevelState : SimpleState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IPlayerFactory _playerFactory;
        private readonly IStaticDataProvider _staticDataProvider;
        private readonly IGameStateMachine _gameStateMachine;

        private UpdateFeature _updateFeature;
        
        public LoadLevelState(ISceneLoader sceneLoader,
            IStaticDataProvider staticDataProvider,
            IGameStateMachine gameStateMachine,
            IPlayerFactory playerFactory)
        {
            _sceneLoader = sceneLoader;
            _playerFactory = playerFactory;
            _staticDataProvider = staticDataProvider;
            _gameStateMachine = gameStateMachine;
        }
        
        public override async void Enter()
        {
            await _sceneLoader.Load(SceneConstants.GameSceneName);
            
            _playerFactory.CreatePlayer(_staticDataProvider.PlayerSettings.SpawnPosition);
            _gameStateMachine.Enter<GameLoopState>();
        }
    }
}