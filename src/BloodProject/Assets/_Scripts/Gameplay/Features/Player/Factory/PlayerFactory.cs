using System.Collections.Generic;
using _Scripts.Common.Entity;
using _Scripts.Common.Extensions;
using _Scripts.Infrastructure.Services.Identifiers;
using _Scripts.Infrastructure.Services.StaticData.Provider;
using Gameplay.Features.EntitiesStats;
using UnityEngine;

namespace Gameplay.Features.Player.Factory
{
  public class PlayerFactory : IPlayerFactory
  {
    private readonly IStaticDataProvider _staticDataProvider;

    public PlayerFactory(IStaticDataProvider staticDataProvider)
    {
      _staticDataProvider = staticDataProvider;
    }

    public GameEntity CreatePlayer(Vector2 position)
    {
      Dictionary<Stats, float> baseStats = new Dictionary<Stats, float>()
          .With(x => x[Stats.Speed] = _staticDataProvider.PlayerSettings.MoveSpeed)
          .With(x => x[Stats.MaxHeath] = _staticDataProvider.PlayerSettings.InitHealth);
      
      return CreateEntity.Empty()
        .AddId(IdentifierService.Next())
        .AddWorldPosition(position)
        .AddMoveSmooth(_staticDataProvider.PlayerSettings.MoveSmooth)
        .AddDirection(Vector2.zero)
        .AddBaseStats(baseStats)
        .AddSpeed(baseStats[Stats.Speed])
        .AddMaxHealth(baseStats[Stats.MaxHeath])
        .AddCurrentHealth(baseStats[Stats.MaxHeath])
        .AddStatModifiers(baseStats.GetSameDefaultDictionary())
        .AddViewReference(_staticDataProvider.PlayerSettings.Prefab)
        .With(x => x.isPlayer = true)
        .With(x => x.isTurnedAlongDirection = true)
        .With(x => x.isMovementAvailable = true)
        .With(x => x.isTeleport = true)
        .With(x => x.isMoveByPhysic = true)
        .With(x => x.isDead = false);
    }
  }
}