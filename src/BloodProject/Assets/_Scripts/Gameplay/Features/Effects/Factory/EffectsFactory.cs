using System;
using _Scripts.Common.Entity;
using _Scripts.Common.Extensions;
using _Scripts.Gameplay.Features.Effects.Data;
using Gameplay.Features.Effects.Data;
using Gameplay.Features.Effects.Factory;

namespace _Scripts.Gameplay.Features.Effects.Factory
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
      }
      
      throw new Exception($"Effect with type id {effectSetup.EffectTypeId} does not exist");
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