using Cysharp.Threading.Tasks;

namespace _Scripts.Infrastructure.StateMachine.StateInfrastructure
{
  public interface IExitableState
  {
    UniTask BeginExit();
    void EndExit();
  }
}