using Entitas;
using UnityEngine;

namespace Gameplay.Features.Effects.Systems
{
  public class ProcessPushEffectsSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _effects;
    
    public ProcessPushEffectsSystem(GameContext gameContext)
    {
      _effects = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.DamageEffect,
          GameMatcher.EffectValue,
          GameMatcher.TargetId,
          GameMatcher.ProducerId
        ));
    }
    
    public void Execute()
    {
      foreach (var effect in _effects)
      {
        GameEntity target = effect.Target();
        GameEntity producer = effect.Producer();
        
        effect.isProcessed = true;
        
        if (target.isDead)
          continue;

        if (target.hasRigidbody)
        {
          Debug.Log(producer.Transform.name);
          Vector2 direction = (target.Transform.position - producer.Transform.position).normalized;
          target.Rigidbody.AddForce(direction * effect.EffectValue, ForceMode.Impulse);
        }
      }
    }
  }
}