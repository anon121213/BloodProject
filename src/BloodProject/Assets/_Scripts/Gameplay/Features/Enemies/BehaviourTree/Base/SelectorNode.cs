using System.Collections.Generic;

namespace _Scripts.Gameplay.Features.Enemies.BehaviourTree.Base
{
  public class SelectorNode : Node
  {
    private readonly List<Node> _nodes;

    public SelectorNode(List<Node> nodes) =>
      _nodes = nodes;

    public override NodeStatus Execute(GameEntity entity)
    {
      foreach (var node in _nodes)
      {
        NodeStatus result = node.Execute(entity);
        
        if (result != NodeStatus.Failure)
          return result;
      }
      return NodeStatus.Failure;
    }
  }
}