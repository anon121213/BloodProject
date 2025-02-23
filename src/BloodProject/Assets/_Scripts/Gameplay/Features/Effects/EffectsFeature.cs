using _Scripts.Infrastructure.Services.Factories.SystemsFactory;
using Gameplay.Features.Effects.Systems;

namespace _Scripts.Gameplay.Features.Effects
{
  public sealed class EffectsFeature : Feature
  {
    public EffectsFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<ProcessCleanupEffectsSystem>());
      Add(systemFactory.Create<ProcessDamageEffectSystem>());
      Add(systemFactory.Create<ProcessPushEffectsSystem>());
    }
  }
}