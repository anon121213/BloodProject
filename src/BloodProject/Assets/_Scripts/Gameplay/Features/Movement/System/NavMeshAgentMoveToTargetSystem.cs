using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Movement.System
{
  public class NavMeshAgentMoveToTargetSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _agents;

    public NavMeshAgentMoveToTargetSystem(GameContext gameContext)
    {
      _agents = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.NavMeshAgent,
          GameMatcher.MoveByNavMesh,
          GameMatcher.NavMashTargetPosition,
          GameMatcher.Moving,
          GameMatcher.MovementAvailable,
          GameMatcher.Speed
        ));
    }

    public void Execute()
    {
      foreach (var agent in _agents)
      {
        Debug.Log("Move");
        agent.NavMeshAgent.SetDestination(agent.NavMashTargetPosition);
        agent.NavMeshAgent.speed = agent.Speed;
      } 
    }
  }
}