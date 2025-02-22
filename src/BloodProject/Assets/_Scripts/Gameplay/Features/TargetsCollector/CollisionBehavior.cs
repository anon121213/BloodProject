using _Scripts.Infrastructure.View;
using UnityEngine;

namespace _Scripts.Gameplay.Features.TargetsCollector
{
  public class CollisionBehavior : MonoBehaviour
  {
    [SerializeField] private EntityBehaviour _entityView;
    [SerializeField] private LayerMask _ignoreLayers;
    
    private void OnTriggerEnter(Collider other)
    {
      if (!IsLayerIgnored(other.gameObject.layer)) 
        _entityView.Entity.isCollide = true; 
    }
    
    private bool IsLayerIgnored(int layer) => 
      (_ignoreLayers.value & (1 << layer)) != 0;
  }
}