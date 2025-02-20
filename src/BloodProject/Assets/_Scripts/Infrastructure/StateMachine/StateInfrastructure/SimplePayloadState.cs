using Cysharp.Threading.Tasks;

namespace _Scripts.Infrastructure.StateMachine.StateInfrastructure
{
  public class SimplePayloadState<TPayload> : IPayloadState<TPayload>
  {
    public virtual void Enter(TPayload payload) { }
    protected virtual void Exit() { }

    public UniTask BeginExit()
    {
      Exit();
      return UniTask.CompletedTask;
    }

    public void EndExit() { }
  }
}