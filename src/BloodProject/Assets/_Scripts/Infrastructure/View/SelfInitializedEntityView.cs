using _Scripts.Common.Entity;
using _Scripts.Infrastructure.Services.Identifiers;
using UnityEngine;

namespace _Scripts.Infrastructure.View
{
  public class SelfInitializedEntityView : MonoBehaviour
  {
    public EntityBehaviour EntityBehaviour;

    private void Awake()
    {
      GameEntity entity = CreateEntity.Empty()
        .AddId(IdentifierService.Next());
      
      EntityBehaviour.SetEntity(entity);
    }
  }
}