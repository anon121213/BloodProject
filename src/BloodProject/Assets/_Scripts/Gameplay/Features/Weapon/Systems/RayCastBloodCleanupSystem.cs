using System.Collections.Generic;
using Entitas;

namespace _Scripts.Gameplay.Features.Weapon.Systems
{
  public class RayCastBloodCleanupSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(32);

    public RayCastBloodCleanupSystem(GameContext gameContext)
    {
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.HitNormals,
          GameMatcher.HitPoints,
          GameMatcher.Hittables
        ));
    }

    public void Cleanup()
    {
      foreach (var entity in _entities.GetEntities(_buffer))
      {
        entity.RemoveHitNormals();
        entity.RemoveHitPoints();
        entity.RemoveHittables();
      }
    }
  }
}