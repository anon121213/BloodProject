namespace _Scripts.Gameplay.Features.Enemies.BehaviourTree.Base
{
  public abstract class Node
  {
    protected NodeStatus Status;
    public abstract NodeStatus Execute(GameEntity entity);
  }
  
  public enum NodeStatus
  {
    Running,
    Success,
    Failure
  }
}