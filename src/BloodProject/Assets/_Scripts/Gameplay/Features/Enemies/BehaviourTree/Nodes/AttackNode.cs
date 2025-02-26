using _Scripts.Common.Physics;
using _Scripts.Gameplay.Features.Enemies.BehaviourTree.Base;
using Gameplay.Features.Effects.Factory;

namespace _Scripts.Gameplay.Features.Enemies.BehaviourTree.Nodes
{
  public class AttackNode : Node
  {
    private readonly IPhysicsService _physicsService;
    private readonly IEffectsFactory _effectsFactory;

    public AttackNode(IPhysicsService physicsService,
      IEffectsFactory effectsFactory)
    {
      _physicsService = physicsService;
      _effectsFactory = effectsFactory;
    }

    public override NodeStatus Execute(GameEntity entity)
    {
      if (!entity.isAttackAvailable
          || !entity.hasAttackPoint
          || !entity.hasAttackRadius
          || !entity.hasEffectSetups)
        return NodeStatus.Failure;

      int length = _physicsService.OverlapSphereNonAlloc(entity.AttackPoint.position,
        entity.AttackRadius, out GameEntity[] results, entity.TargetsLayerMask);

      if (length <= 0)
        return NodeStatus.Failure;

      foreach (var target in results)
      foreach (var effect in entity.EffectSetups)
      {
        if (entity.AttackCombo < entity.MaxAttackCombo)
          entity.ReplaceAttackCombo(entity.AttackCombo + 1);
        else
          entity.ReplaceAttackCombo(0);
        
        entity.isAttack = true;
        _effectsFactory.CreateEffect(effect, entity.Id, target.Id);
      }

      return NodeStatus.Success;
    }
  }
}