using Cysharp.Threading.Tasks;

namespace _Scripts.Infrastructure.StateMachine.StateInfrastructure
{
  public class SimpleState : IState
  {
    public virtual void Enter() { }
    protected virtual void Exit() { }

    public UniTask BeginExit()
    {
      Exit();
      return UniTask.CompletedTask;
    }

    public void EndExit() { }
  }
}