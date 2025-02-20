using _Scripts.Infrastructure.StateMachine.StateInfrastructure;

namespace _Scripts.Infrastructure.StateMachine.States
{
    public class BootstrapState : SimpleState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public BootstrapState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public override void Enter()
        {
            _gameStateMachine.Enter<LoadLevelState>();
        }
    }
}