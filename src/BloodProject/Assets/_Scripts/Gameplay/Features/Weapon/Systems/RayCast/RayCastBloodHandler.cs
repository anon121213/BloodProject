using System.Collections.Generic;
using Entitas;
using Knife.RealBlood;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Weapon.Systems
{
  public class RayCastBloodHandler : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _weapons;
    private readonly List<GameEntity> _buffer = new(64);

    public RayCastBloodHandler(GameContext gameContext)
    {
      _weapons = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.HitPoints,
          GameMatcher.HitNormals,
          GameMatcher.Hittables
        ));
    }

    public void Execute()
    {
      foreach (var weapon in _weapons.GetEntities(_buffer))
      {
        for (int i = 0; i < weapon.Hittables.Count; i++)
        {
          DamageData data = new DamageData
          {
            point = weapon.HitPoints[i],
            normal = weapon.HitNormals[i],
          };

          DamageData[] datas = new DamageData[1];
          datas[0] = data;

          weapon.Hittables[i].TakeDamage(datas);
        }
        
        weapon.isShotProcessed = true;
      }
    }
  }
}