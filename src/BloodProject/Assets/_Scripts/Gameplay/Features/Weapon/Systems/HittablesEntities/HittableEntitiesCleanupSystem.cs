using System.Collections.Generic;
using Entitas;

namespace _Scripts.Gameplay.Features.Weapon.Systems.HittablesEntities
{
  public class HittableEntitiesCleanupSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(32);

    public HittableEntitiesCleanupSystem(GameContext gameContext)
    {
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(GameMatcher.HittablesEntities));
    }
    
    public void Cleanup()
    {
      foreach (var entity in _entities.GetEntities(_buffer)) 
        entity.RemoveHittablesEntities();
    }
  }
}