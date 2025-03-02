using System.Collections.Generic;
using _Scripts.Common.Physics;
using Entitas;
using Knife.RealBlood;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Weapon.Systems
{
  public class ShotgunRayCastWeaponSystem : IExecuteSystem
  {
    private readonly IPhysicsService _physicsService;
    private readonly IGroup<GameEntity> _weapons;
    private readonly IGroup<InputEntity> _inputs;
    private readonly IGroup<GameEntity> _camera;
    private readonly List<GameEntity> _buffer = new(1);

    private readonly List<IHittable> _hittables = new();
    private readonly List<Vector3> _normals = new();
    private readonly List<Vector3> _points = new();

    public ShotgunRayCastWeaponSystem(GameContext gameContext,
      InputContext inputContext,
      IPhysicsService physicsService)
    {
      _physicsService = physicsService;
      _camera = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Camera
        ));

      _weapons = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Weapon,
          GameMatcher.AttackAvailable,
          GameMatcher.RaycastShooter,
          GameMatcher.Shotgun,
          GameMatcher.IgnoreLayers,
          GameMatcher.PelletCount,
          GameMatcher.SpredAngleX,
          GameMatcher.SpredAngleY,
          GameMatcher.RayDistance
        ));

      _inputs = inputContext.GetGroup(InputMatcher
        .AllOf(
          InputMatcher.Input
        ));
    }

    public void Execute()
    {
      foreach (var input in _inputs)
      foreach (var camera in _camera)
      foreach (var weapon in _weapons.GetEntities(_buffer))
      {
        if (!weapon.isAttackAvailable || !input.isShooting)
          continue;

        weapon.isAttack = true;
        Shoot(weapon, camera.Camera, weapon.IgnoreLayers);
      }
    }

    private void Shoot(GameEntity weapon, UnityEngine.Camera camera, LayerMask ignoreLayerMask)
    {
      _hittables.Clear();
      _normals.Clear();
      _points.Clear();

      for (int i = 0; i < weapon.PelletCount; i++)
      {
        Vector3 direction = GetSpreadDirection(weapon, camera);
        _physicsService.RayCast(camera.transform.position, direction, weapon.RayDistance, out RaycastHit hit,
          ~ignoreLayerMask);

        if (hit.collider == null)
          continue;

        if (hit.collider.TryGetComponent(out IHittable hittable))
        {
          _hittables.Add(hittable);
          _normals.Add(hit.normal);
          _points.Add(hit.point);
        }
      }

      weapon.ReplaceHittables(_hittables);
      weapon.ReplaceHitPoints(_points);
      weapon.ReplaceHitNormals(_normals);
      weapon.isShotProcessed = false;
    }


    Vector3 GetSpreadDirection(GameEntity weapon, UnityEngine.Camera camera)
    {
      Vector3 baseDirection = camera.transform.forward;

      float angleY = Random.Range(-weapon.SpredAngleX, weapon.SpredAngleX);
      float angleX = Random.Range(-weapon.SpredAngleY, weapon.SpredAngleY);

      Quaternion spreadRotation = Quaternion.Euler(angleX, angleY, 0);
      return spreadRotation * baseDirection;
    }
  }
}