using Entitas;
using UnityEngine;

namespace Gameplay.Features.Effects.Systems
{
  public class ProcessDamageEffectSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _effects;

    public ProcessDamageEffectSystem(GameContext gameContext)
    {
      _effects = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.DamageEffect,
          GameMatcher.EffectValue,
          GameMatcher.TargetId
        ));
    }
    
    public void Execute()
    {
      foreach (var effect in _effects)
      {
        GameEntity target = effect.Target();

        effect.isProcessed = true;
        
        if (target.isDead || !target.hasCurrentHealth)
          continue;
        
        target.ReplaceCurrentHealth(Mathf.Clamp(target.CurrentHealth - effect.EffectValue, 0, target.MaxHealth));
      }
    }
  }
}