using Entitas;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Infrastructure.Services.Factories.SystemsFactory
{
  public class SystemFactory : ISystemFactory
  {
    private readonly LifetimeScope _parentScope;

    public SystemFactory(LifetimeScope parentScope) => 
      _parentScope = parentScope;

    public T Create<T>() where T : ISystem =>
      _parentScope.CreateChild(builder =>
        builder.Register<T>(Lifetime.Transient)).Container.Resolve<T>();
  }
}