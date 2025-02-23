using _Scripts.Common.Collisions;
using _Scripts.Infrastructure.View;
using UnityEngine;
using VContainer;

namespace _Scripts.Gameplay.Features.Collides
{
  public class CollisionBehavior : MonoBehaviour
  {
    [SerializeField] private EntityBehaviour _entityView;
    [SerializeField] private LayerMask _ignoreLayers;
    
    private ICollisionRegistry _collisionRegistry;

    [Inject]
    private void Construct(ICollisionRegistry collisionRegistry)
    {
      _collisionRegistry = collisionRegistry;
    }
    
    private void OnTriggerEnter(Collider collider)
    {
      if (IsLayerIgnored(collider.gameObject.layer))
        return;
      
      GameEntity entity = _collisionRegistry.Get<GameEntity>(collider.GetInstanceID());
        
      if (entity != null) 
        _entityView.Entity.ReplaceCollideEntity(entity);
      
      _entityView.Entity.isCollide = true;
      _entityView.Entity.ReplaceCollideEntityCollider(collider);
    }
    
    private bool IsLayerIgnored(int layer) => 
      (_ignoreLayers.value & (1 << layer)) != 0;
  }
}