using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Infrastructure.View.Factory
{
  public interface IEntityViewFactory
  {
    UniTask<EntityBehaviour> CreateViewForEntity(GameEntity entity, Transform root);
    EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity, Transform root);
  }
}