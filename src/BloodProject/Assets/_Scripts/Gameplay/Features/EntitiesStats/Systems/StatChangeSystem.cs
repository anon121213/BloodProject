using _Scripts.Common.EntityIndices;
using Entitas;

namespace Gameplay.Features.EntitiesStats.Systems
{
  public class StatChangeSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _statsOwners;
    private readonly GameContext _game;

    public StatChangeSystem(GameContext game)
    {
      _game = game;

      _statsOwners = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Id,
          GameMatcher.BaseStats,
          GameMatcher.StatModifiers
        ));
    }

    public void Execute()
    {
      foreach (GameEntity statOwner in _statsOwners)
      foreach (Stats stat in statOwner.BaseStats.Keys)
      {
        statOwner.StatModifiers[stat] = 0;
        
        foreach (GameEntity statChange in _game.TargetStatChanges(stat, statOwner.Id)) 
          statOwner.StatModifiers[stat] += statChange.EffectValue;
      }
    }
  }
}