using System;
using _Scripts.Common.Entity;
using _Scripts.Common.Extensions;
using Gameplay.Features.Effects.Data;

namespace Gameplay.Features.Effects.Factory
{
  public class EffectsFactory : IEffectsFactory
  {
    public GameEntity CreateEffect(EffectSetup effectSetup, int producerId, int targetId)
    {
      switch (effectSetup.EffectTypeId)
      {
        case EffectTypeId.Unknown:
          break;
        case EffectTypeId.Damage:
          return CreateDamageEffect(producerId, targetId, effectSetup.Value);
        case EffectTypeId.Push:
          return CreatePushEffect(producerId, targetId, effectSetup.Value);
      }
      
      throw new Exception($"Effect with type id {effectSetup.EffectTypeId} does not exist");
    }

    private GameEntity CreatePushEffect(int producerId, int targetId, float effectValue)
    {
      return CreateEntity.Empty()
        .AddEffectValue(effectValue)
        .AddProducerId(producerId)
        .AddTargetId(targetId)
        .With(x => x.isEffect = true)
        .With(x => x.isPushEffect = true);
    }

    private GameEntity CreateDamageEffect(int producerId, int targetId, float effectValue)
    {
      return CreateEntity.Empty()
        .AddEffectValue(effectValue)
        .AddProducerId(producerId)
        .AddTargetId(targetId)
        .With(x => x.isEffect = true)
        .With(x => x.isDamageEffect = true);
    }
  }
}