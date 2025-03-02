using Entitas;
using Gameplay.Features.Effects.Factory;

namespace _Scripts.Gameplay.Features.Weapon.Systems
{
  public class RayCastDamageSystem : IExecuteSystem
  {
    private readonly IEffectsFactory _effectsFactory;
    private readonly IGroup<GameEntity> _entities;

    public RayCastDamageSystem(GameContext gameContext,
      IEffectsFactory effectsFactory)
    {
      _effectsFactory = effectsFactory;

      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.HittablesEntities,
          GameMatcher.EffectSetups,
          GameMatcher.ProducerId
        ).NoneOf(GameMatcher.ShotProcessed));
    }

    public void Execute()
    {
      foreach (var entity in _entities)
      foreach (var hittable in entity.HittablesEntities)
      foreach (var effect in entity.EffectSetups)
      {
        _effectsFactory.CreateEffect(effect, entity.ProducerId, hittable.Id);
      }
    }
  }
}