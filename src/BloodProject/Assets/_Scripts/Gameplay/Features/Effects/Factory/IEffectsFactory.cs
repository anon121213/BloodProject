using Gameplay.Features.Effects.Data;

namespace Gameplay.Features.Effects.Factory
{
  public interface IEffectsFactory
  {
    GameEntity CreateEffect(EffectSetup effectSetup, int producerId, int targetId);
  }
}