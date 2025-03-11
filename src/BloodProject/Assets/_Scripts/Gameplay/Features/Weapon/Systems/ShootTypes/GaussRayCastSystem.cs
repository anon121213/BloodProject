using System.Collections.Generic;
using _Scripts.Gameplay.Features.Projectiles.Factory;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Weapon.Systems.ShootTypes
{
  public class GaussRayCastSystem : IExecuteSystem
  {
    private readonly IProjectileFactory _projectileFactory;
    private readonly IGroup<GameEntity> _weapons;
    private readonly List<GameEntity> _buffer = new(1);

    private readonly List<Vector3> _rayPositions = new();
    private readonly List<Vector3> _rayDirections = new();
    private readonly IGroup<GameEntity> _players;

    public GaussRayCastSystem(GameContext gameContext, IProjectileFactory projectileFactory)
    {
      _projectileFactory = projectileFactory;

      _weapons = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Weapon,
          GameMatcher.Gauss,
          GameMatcher.RaycastShooter,
          GameMatcher.AttackPoint,
          GameMatcher.Attack,
          GameMatcher.PushDuration,
          GameMatcher.PushDistance
        ));

      _players = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Player,
          GameMatcher.CharacterController,
          GameMatcher.Camera
        ));
    }

    public void Execute()
    {
      foreach (var player in _players)
      foreach (var weapon in _weapons.GetEntities(_buffer))
      {
        _rayDirections.Clear();
        _rayPositions.Clear();
        
        Vector3 shotDirection = GetShotDirectionDirection(weapon.AttackPoint, player.Camera, out Vector3 point);

        var projectile = _projectileFactory.CreateTeleportProjectile(weapon.ProjectileData,
          weapon.OwnerID, weapon.AttackPoint.position, point);
        
        Debug.Log(projectile);
        
        _rayPositions.Add(weapon.AttackPoint.position);
        _rayDirections.Add(shotDirection);

        weapon.ReplaceShootRaycastPosition(_rayPositions);
        weapon.ReplaceShootRaycastDirecion(_rayDirections);
        weapon.isAttack = true;

        player.ReplacePushDirection(-player.Camera.transform.forward);
        player.ReplacePushDistance(weapon.PushDistance);
        player.ReplacePushDuration(weapon.PushDuration);
        player.ReplaceCurrentPushDuration(0);
        player.isPushing = true;
      }
    }

    Vector3 GetShotDirectionDirection(Transform attackPoint, UnityEngine.Camera camera, out Vector3 hitPoint)
    {
      Ray ray = camera.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));
      float rayDistance = 100f;

      Vector3 targetPoint = ray.GetPoint(rayDistance);
      Vector3 direction = targetPoint - attackPoint.position;

      if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
      {
        targetPoint = hit.point; 
        direction = targetPoint - attackPoint.position;
      }

      hitPoint = targetPoint;
      return direction;
    }
  }
}