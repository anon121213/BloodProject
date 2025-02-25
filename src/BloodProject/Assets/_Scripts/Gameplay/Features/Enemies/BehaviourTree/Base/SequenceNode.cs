using System.Collections.Generic;

namespace _Scripts.Gameplay.Features.Enemies.BehaviourTree.Base
{
  public class SequenceNode : Node
  {
    private readonly List<Node> _nodes;

    public SequenceNode(List<Node> nodes) =>
      _nodes = nodes;

    public override NodeStatus Execute(GameEntity entity)
    {
      foreach (var node in _nodes)
      {
        var result = node.Execute(entity);
        
        if (result == NodeStatus.Failure)
          return NodeStatus.Failure;
        
        if (result == NodeStatus.Running)
          return NodeStatus.Running;
      }
      return NodeStatus.Success;
    }
  }
}