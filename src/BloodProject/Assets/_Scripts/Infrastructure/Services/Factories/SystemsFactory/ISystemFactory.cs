using Entitas;

namespace _Scripts.Infrastructure.Services.Factories.SystemsFactory
{
  public interface ISystemFactory
  {
    T Create<T>() where T : ISystem;
  }
}