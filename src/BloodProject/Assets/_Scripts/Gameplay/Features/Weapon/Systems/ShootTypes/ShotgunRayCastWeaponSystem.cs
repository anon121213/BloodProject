using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Weapon.Systems.ShootTypes
{
  public class ShotgunRayCastWeaponSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _weapons;
    private readonly IGroup<GameEntity> _camera;
    private readonly List<GameEntity> _buffer = new(1);

    private readonly List<Vector3> _rayPositions = new();
    private readonly List<Vector3> _rayDirections = new();

    public ShotgunRayCastWeaponSystem(GameContext gameContext)
    {
      _camera = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Camera
        ));

      _weapons = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Weapon,
          GameMatcher.RaycastShooter,
          GameMatcher.Shotgun,
          GameMatcher.PelletCount,
          GameMatcher.SpredAngleX,
          GameMatcher.SpredAngleY,
          GameMatcher.Attack
        ));
    }

    public void Execute()
    {
      foreach (var camera in _camera)
      foreach (var weapon in _weapons.GetEntities(_buffer))
      {
        _rayDirections.Clear();
        _rayPositions.Clear();
        
        for (int i = 0; i < weapon.PelletCount; i++)
        {
          _rayPositions.Add(camera.Camera.transform.position);
          _rayDirections.Add(GetSpreadDirection(weapon, camera.Camera));
        }
        
        weapon.ReplaceShootRaycastPosition(_rayPositions);
        weapon.ReplaceShootRaycastDirecion(_rayDirections);
        weapon.isAttack = true;
      }
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