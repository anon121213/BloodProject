using Entitas;
using Gameplay.Features.Effects.Factory;

namespace Gameplay.Features.Projectiles.Systems
{
  public class ApplyProjectilesEffectOnTargetsSystem : IExecuteSystem
  {
    private readonly IEffectsFactory _effectsFactory;
    private readonly IGroup<GameEntity> _projectiles;

    public ApplyProjectilesEffectOnTargetsSystem(GameContext gameContext, IEffectsFactory effectsFactory)
    {
      _effectsFactory = effectsFactory;
      _projectiles = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.TargetsBuffer,
          GameMatcher.Projectile,
          GameMatcher.EffectSetups
        ));
    }

    public void Execute()
    {
      foreach (var projectile in _projectiles)
      foreach (var target in projectile.TargetsBuffer)
      foreach (var effect in projectile.EffectSetups)
      {
        _effectsFactory.CreateEffect(effect, projectile.ProducerId, target);
      }
    }
  }
}