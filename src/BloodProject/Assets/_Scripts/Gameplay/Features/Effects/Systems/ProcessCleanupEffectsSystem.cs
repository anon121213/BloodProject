using System.Collections.Generic;
using Entitas;

namespace Gameplay.Features.Effects.Systems
{
  public class ProcessCleanupEffectsSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _effects;
    private readonly List<GameEntity> _buffer = new(64);

    public ProcessCleanupEffectsSystem(GameContext gameContext)
    {
      _effects = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Effect,
          GameMatcher.Processed
        ));
    }
    
    public void Execute()
    {
      foreach (var effect in _effects.GetEntities(_buffer)) 
        effect.Destroy();
    }
  }
}