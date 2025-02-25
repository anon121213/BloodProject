using System.Collections.Generic;
using _Scripts.Common.Collisions;
using _Scripts.Gameplay.Features.ProjectilesCollides;
using UnityEngine;

namespace _Scripts.Common.Physics
{
  public class PhysicsService : IPhysicsService
  {
    private static readonly RaycastHit[] Hits = new RaycastHit[128];
    private static readonly Collider[] OverlapHits = new Collider[128];
    private static readonly GameEntity[] OverlapEntities = new GameEntity[128];

    private readonly ICollisionRegistry _collisionRegistry;

    public PhysicsService(ICollisionRegistry collisionRegistry)
    {
      _collisionRegistry = collisionRegistry;
    }

    public IEnumerable<GameEntity> RaycastAll(Vector3 worldPosition, Vector3 direction, int layerMask)
    {
      int hitCount = UnityEngine.Physics.RaycastNonAlloc(worldPosition, direction, Hits, layerMask);

      for (int i = 0; i < hitCount; i++)
      {
        RaycastHit hit = Hits[i];
        if (hit.collider == null)
          continue;

        GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.collider.GetInstanceID());
        if (entity == null)
          continue;

        yield return entity;
      }
    }

    public GameEntity Raycast(Vector3 worldPosition, Vector3 direction, int layerMask)
    {
      int hitCount = UnityEngine.Physics.RaycastNonAlloc(worldPosition, direction, Hits, layerMask);

      for (int i = 0; i < hitCount; i++)
      {
        RaycastHit hit = Hits[i];
        if (hit.collider == null)
          continue;

        GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.collider.GetInstanceID());
        if (entity == null)
          continue;

        return entity;
      }

      return null;
    }

    public GameEntity LineCast(Vector3 start, Vector3 end, int layerMask, out Collider outHit)
    {
      UnityEngine.Physics.Linecast(start, end, out RaycastHit hit, layerMask);

      Debug.DrawLine(start, end, Color.green, 3);

      if (hit.collider)
      {
        GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.collider.GetInstanceID());
        outHit = hit.collider;
        return entity;
      }

      outHit = null;
      return null;
    }

    public int OverlapSphereNonAlloc(Vector3 worldPosition, float radius, out GameEntity[] results, int layerMask)
    {
      int hitCount = UnityEngine.Physics.OverlapSphereNonAlloc(worldPosition, radius, OverlapHits, layerMask);

      int entityCount = 0;
      for (int i = 0; i < hitCount; i++)
      {
        Collider hit = OverlapHits[i];
        if (hit == null)
          continue;

        GameEntity entity = _collisionRegistry.Get<GameEntity>(hit.GetInstanceID());
        if (entity == null)
          continue;

        OverlapEntities[entityCount] = entity;
        entityCount++;
      }

      results = new GameEntity[entityCount];
      System.Array.Copy(OverlapEntities, results, entityCount);

      return entityCount;
    }
  }
}