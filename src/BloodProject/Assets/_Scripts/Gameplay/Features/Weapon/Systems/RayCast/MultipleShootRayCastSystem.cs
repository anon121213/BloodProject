using System.Collections.Generic;
using _Scripts.Common.Physics;
using Entitas;
using Knife.RealBlood;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Weapon.Systems.RayCast
{
  public class MultipleShootRayCastSystem : IExecuteSystem
  {
    private readonly IPhysicsService _physicsService;
    private readonly IGroup<GameEntity> _entities;
    
    private readonly List<IHittable> _hittables = new();
    private readonly List<Vector3> _normals = new();
    private readonly List<Vector3> _points = new();
    private readonly List<GameEntity> _hittablesEntities = new();

    public MultipleShootRayCastSystem(GameContext gameContext,
      IPhysicsService physicsService)
    {
      _physicsService = physicsService;
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.RaycastShooter,
          GameMatcher.ShootRaycastDirecion,
          GameMatcher.ShootRaycastPosition,
          GameMatcher.IgnoreLayers,
          GameMatcher.RayDistance,
          GameMatcher.OwnerID
        ));
    }

    public void Execute()
    {
      foreach (var entity in _entities)
      {
        _hittables.Clear();
        _normals.Clear();
        _points.Clear();
        _hittablesEntities.Clear();
        
        foreach (var position in entity.ShootRaycastPosition)
        foreach (var direction in entity.ShootRaycastDirecion)
        {
          GameEntity hitEntity = _physicsService.RayCast(position, direction,
            entity.RayDistance, out RaycastHit hit, ~entity.IgnoreLayers);

          if (hit.collider == null)
            continue;
          
          if (hit.collider.TryGetComponent(out IHittable hittable))
          {
            _hittables.Add(hittable);
            _normals.Add(hit.normal);
            _points.Add(hit.point);

            if (hitEntity != null)
              _hittablesEntities.Add(hitEntity);
          }
        }
        
        entity.ReplaceHittablesEntities(_hittablesEntities);
        entity.ReplaceProducerId(entity.OwnerID);
        entity.ReplaceHittables(_hittables);
        entity.ReplaceHitPoints(_points);
        entity.ReplaceHitNormals(_normals);
      }
    }
  }
}