
using Cysharp.Threading.Tasks;

namespace _Scripts.Infrastructure.StateMachine.StateInfrastructure
{
  public class EndOfFrameExitState : IState, IUpdateable, IFixedUpdateable
  {
    private UniTaskCompletionSource _exitTaskSource;

    protected bool ExitWasRequested => _exitTaskSource != null;

    public virtual void Enter() {}

    public UniTask BeginExit()
    {
      _exitTaskSource = new UniTaskCompletionSource();
      return _exitTaskSource.Task;
    }

    public void EndExit()
    {
      ExitOnEndOfFrame();
      ResolveExitTask();
    }

    public void Update()
    {
      if (!ExitWasRequested)
        OnUpdate();
            
      if (ExitWasRequested) 
        ResolveExitTask();
    }

    public void FixedUpdate()
    {
      if (!ExitWasRequested)
        OnFixedUpdate();
            
      if (ExitWasRequested) 
        ResolveExitTask();
    }

    protected virtual void ExitOnEndOfFrame() {}

    protected virtual void OnUpdate() {}
    protected virtual void OnFixedUpdate() {}

    private void ResolveExitTask()
    {
      _exitTaskSource?.TrySetResult();
      _exitTaskSource = null;
    }
  }
}