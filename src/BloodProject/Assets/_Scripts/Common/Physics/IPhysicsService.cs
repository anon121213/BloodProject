using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Common.Physics
{
  public interface IPhysicsService
  {
    GameEntity Raycast(Vector3 worldPosition, Vector3 direction, int layerMask);
    GameEntity LineCast(Vector3 start, Vector3 end, int layerMask, out Collider collider);
    IEnumerable<GameEntity> RaycastAll(Vector3 worldPosition, Vector3 direction, int layerMask);
    int OverlapSphereNonAlloc(Vector3 worldPosition, float raduis, out GameEntity[] results, int layerMask);
  }
}