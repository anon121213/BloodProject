using _Scripts.Infrastructure.StateMachine.Factory;
using _Scripts.Infrastructure.StateMachine.StateInfrastructure;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace _Scripts.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine, ITickable, IFixedTickable
    {
        private IExitableState _activeState;
        private readonly IStateFactory _stateFactory;

        public GameStateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Tick()
        {
            if (_activeState is IUpdateable updateableState)
                updateableState.Update();
        }
        
        public void FixedTick()
        {
            if (_activeState is IFixedUpdateable updateableState)
                updateableState.FixedUpdate();
        }

        public async UniTask Enter<TState>() where TState : class, IState
        {
            var state = await RequestChangeState<TState>();
            EnterState(state);
        }

        public async UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            var state = await RequestChangeState<TState>();
            EnterPayloadState(state, payload);
        }

        private void EnterState<TState>(TState state) where TState : class, IState
        {
            _activeState = state;
            state.Enter();
        }

        private void EnterPayloadState<TState, TPayload>(TState state, TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            _activeState = state;
            state.Enter(payload);
        }

        private async UniTask<TState> RequestChangeState<TState>() where TState : class, IExitableState
        {
            if (_activeState != null)
            {
                await _activeState.BeginExit();
                _activeState.EndExit();
            }

            return ChangeState<TState>();
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            return _stateFactory.CreateSystem<TState>();
        }
    }

    public interface IGameStateMachine
    {
        UniTask Enter<TState>() where TState : class, IState;
        UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
    }
}
