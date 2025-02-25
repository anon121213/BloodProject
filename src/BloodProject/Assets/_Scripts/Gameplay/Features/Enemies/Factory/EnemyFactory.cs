using _Scripts.Common.Entity;
using _Scripts.Common.Extensions;
using _Scripts.Gameplay.Features.Enemies.BehaviourTree.Base;
using _Scripts.Gameplay.Features.Enemies.Data;
using _Scripts.Infrastructure.Services.Identifiers;
using _Scripts.Infrastructure.Services.StaticData.Provider;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Enemies.Factory
{
  public class EnemyFactory : IEnemyFactory
  {
    private readonly IStaticDataProvider _staticDataProvider;

    public EnemyFactory(IStaticDataProvider staticDataProvider) => 
      _staticDataProvider = staticDataProvider;

    public GameEntity CreateEnemy(EnemyType type, Vector3 position, Node rootNode)
    {
      EnemyConfig config = _staticDataProvider.EnemiesConfigs.GetEnemyConfig(type);

      return CreateEntity.Empty()
        .AddId(IdentifierService.Next())
        .AddWorldPosition(position)
        .AddDirection(Vector3.zero)
        .AddSpeed(config.Speed)
        .AddViewReference(config.Prefab)
        .AddRootNode(rootNode)
        .AddCheckPlayerRadius(config.CheckPlayerRadius)
        .AddDistanceToPatrol(config.DistanceToPatrol)
        .AddDistanceToAttackPlayer(config.DistanceToAttackPlayer)
        .AddRotateToPlayerSpeed(config.RotateToPlayerSpeed)
        .AddTargetsLayerMask(config.TargetsLayerMask)
        .AddAttackRadius(config.AttackRadius)
        .AddEffectSetups(config.AttackEffects)
        .AddAttackDelay(config.AttackDelay)
        .AddCurrentAttackDelay(0)
        .With(x => x.isEnemy = true)
        .With(x => x.isAttacker = true)
        .With(x => x.isAttackAvailable = true)
        .With(x => x.isMovementAvailable = true)
        .With(x => x.isTeleport = true)
        .With(x => x.isMoveByNavMesh = true)
        .With(x => x.isBehaviourTree = true);
    }
  }
}