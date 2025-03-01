using System.Collections.Generic;
using System.Linq;
using _Scripts.Common.Entity;
using _Scripts.Common.Extensions;
using _Scripts.Gameplay.Features.Enemies.BehaviourTree.Base;
using _Scripts.Gameplay.Features.Enemies.Data;
using _Scripts.Infrastructure.Services.Identifiers;
using _Scripts.Infrastructure.Services.StaticData.Provider;
using Gameplay.Features.EntitiesStats;
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

      Dictionary<Stats, float> baseStats = new Dictionary<Stats, float>()
        .With(x => x[Stats.Speed] = config.Speed)
        .With(x => x[Stats.MaxHeath] = config.Heath);
      
      return CreateEntity.Empty()
        .AddId(IdentifierService.Next())
        .AddWorldPosition(position)
        .AddDirection(Vector3.zero)
        .AddSpeed(baseStats[Stats.MaxHeath])
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
        .AddMaxAttackCombo(config.MaxAttackCombo)
        .AddAttackCombo(0)
        .AddCurrentAttackDelay(0)
        .AddDestructDelay(config.DeathDestructDelay)
        .AddCurrentHealth(baseStats[Stats.MaxHeath])
        .AddMaxHealth(baseStats[Stats.MaxHeath])
        .AddBaseStats(baseStats)
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