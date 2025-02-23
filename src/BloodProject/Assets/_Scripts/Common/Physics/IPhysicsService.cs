using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Common.Physics
{
  public interface IPhysicsService
  {
    GameEntity Raycast(Vector3 worldPosition, Vector3 direction, int layerMask);
    GameEntity LineCast(Vector3 start, Vector3 end, int layerMask, out Collider collider);
    TEntity OverlapPoint<TEntity>(Vector3 worldPosition, int layerMask) where TEntity : class;
    IEnumerable<GameEntity> RaycastAll(Vector3 worldPosition, Vector3 direction, int layerMask);
    IEnumerable<GameEntity> CircleCast(Vector3 position, float radius, int layerMask);
    int OverlapCircle(Vector3 worldPos, float radius, Collider[] hits, int layerMask);
    int CircleCastNonAlloc(Vector3 position, float radius, int layerMask, GameEntity[] hitBuffer);
  }
}