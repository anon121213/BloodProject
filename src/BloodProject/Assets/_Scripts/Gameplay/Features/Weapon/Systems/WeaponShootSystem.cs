using System.Collections.Generic;
using _Scripts.Gameplay.Features.Projectiles.Factory;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Weapon.Systems
{
  public class WeaponShootSystem : IExecuteSystem
  {
    private readonly IProjectileFactory _projectileFactory;
    private readonly IGroup<GameEntity> _weapons;
    private readonly IGroup<InputEntity> _inputs;
    private readonly List<GameEntity> _buffer = new(1);

    public WeaponShootSystem(GameContext gameContext,
      InputContext inputContext,
      IProjectileFactory projectileFactory)
    {
      _projectileFactory = projectileFactory;
      
      _weapons = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Weapon,
          GameMatcher.ShootAvailable,
          GameMatcher.ProjectileData
        ));

      _inputs = inputContext.GetGroup(InputMatcher
        .AllOf(
          InputMatcher.Input
        ));
    }

    public void Execute()
    {
      foreach (var input in _inputs)
      foreach (var weapon in _weapons.GetEntities(_buffer))
      {
        if (weapon.isShootAvailable && input.isShooting)
        {
          weapon.isShoot = true;
          Shoot(weapon);
        }
      }
    }

    private void Shoot(GameEntity weapon)
    {
      _projectileFactory.CreateSimpleBulletProjectile(weapon.ProjectileData, weapon.Id,
        weapon.AttackPoint.position, Quaternion.identity);
    }
  }
}