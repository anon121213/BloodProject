namespace _Scripts.Infrastructure.StateMachine.StateInfrastructure
{
  public interface IUpdateable
  {
    void Update();
  }

  public interface IFixedUpdateable
  {
    void FixedUpdate();
  }
}