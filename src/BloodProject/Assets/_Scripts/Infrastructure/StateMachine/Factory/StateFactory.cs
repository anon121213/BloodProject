using _Scripts.Infrastructure.StateMachine.StateInfrastructure;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Infrastructure.StateMachine.Factory
{
    public class StateFactory : IStateFactory
    {
        private readonly LifetimeScope _parentScope;

        public StateFactory(LifetimeScope parentScope)
        {
            _parentScope = parentScope;
        }

        public TState CreateSystem<TState>() where TState : class, IExitableState
        {
            return _parentScope.CreateChild(builder =>
                builder.Register<TState>(Lifetime.Transient)).Container.Resolve<TState>();
        }
    }

    public interface IStateFactory
    {
        TState CreateSystem<TState>() where TState : class, IExitableState;
    }
}