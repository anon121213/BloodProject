using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Gravity.Systems
{
  public class CheckGroundSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;

    public CheckGroundSystem(GameContext gameContext)
    {
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.CheckGround,
          GameMatcher.WorldPosition,
          GameMatcher.CheckGroundRadius
        ));
    }

    public void Execute()
    {
      foreach (var entity in _entities)
      {
        bool isGrounded = Physics.CheckSphere(entity.WorldPosition, entity.CheckGroundRadius, ~entity.IgnoreGroundLayers);
        entity.isGrounded = isGrounded;
      }
    }
  }
}