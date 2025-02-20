namespace _Scripts.Infrastructure.StateMachine.StateInfrastructure
{
  public interface IState: IExitableState
  {
    void Enter();
  }
}