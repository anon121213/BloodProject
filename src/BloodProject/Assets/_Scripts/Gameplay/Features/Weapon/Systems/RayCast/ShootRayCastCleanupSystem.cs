using System.Collections.Generic;
using Entitas;

namespace _Scripts.Gameplay.Features.Weapon.Systems.RayCast
{
  public class ShootRayCastCleanupSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(32);

    public ShootRayCastCleanupSystem(GameContext gameContext)
    {
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ShootRaycastDirecion,
          GameMatcher.ShootRaycastPosition
        ));
    }

    public void Cleanup()
    {
      foreach (var entity in _entities.GetEntities(_buffer))
      {
        entity.RemoveShootRaycastDirecion();
        entity.RemoveShootRaycastPosition();
      }
    }
  }
}