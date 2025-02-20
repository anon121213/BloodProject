using _Scripts.Common.Extensions;
using Entitas;

namespace Gameplay.Features.EntitiesStats.Systems
{
  public class ApplySpeedChangeSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _speedEntity;

    public ApplySpeedChangeSystem(GameContext gameContext)
    {
      _speedEntity = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Speed,
          GameMatcher.BaseStats,
          GameMatcher.StatModifiers
        ));
    }

    public void Execute()
    {
      foreach (var entity in _speedEntity) 
        entity.ReplaceSpeed(NewMoveSpeed(entity));
    }

    private static float NewMoveSpeed(GameEntity entity) => 
      (entity.BaseStats[Stats.Speed] + entity.StatModifiers[Stats.Speed]).ZeroIfNegative();
  }
}