using _Scripts.Infrastructure.Services.AssetLoader;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Scripts.Infrastructure.View.Factory
{
  public class EntityViewFactory : IEntityViewFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IObjectResolver _resolver;

    public EntityViewFactory(IAssetProvider assetProvider,
      IObjectResolver resolver)
    {
      _assetProvider = assetProvider;
      _resolver = resolver;
    }
    
    public async UniTask<EntityBehaviour> CreateViewForEntity(GameEntity entity, Transform root)
    {
      EntityBehaviour viewPrefab = await _assetProvider.LoadAsync<EntityBehaviour>(entity.ViewReference);
    
      Vector3 spawnPosition = entity.WorldPosition;
      Quaternion spawnRotation = entity.hasWorldRotation ? entity.WorldRotation : Quaternion.identity;

      EntityBehaviour view = _resolver.Instantiate(
        viewPrefab,
        spawnPosition,
        spawnRotation,
        root);

      view.transform.localPosition = spawnPosition;
      view.transform.localRotation = spawnRotation;
      
      view.SetEntity(entity);
      return view;
    }


    public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity, Transform root)
    {
      Vector3 spawnPosition = entity.WorldPosition;
      Quaternion spawnRotation = entity.hasWorldRotation ? entity.WorldRotation : Quaternion.identity;
      
      EntityBehaviour view = _resolver.Instantiate(
        entity.ViewPrefab,
        root);
      
      view.transform.localPosition = spawnPosition;
      view.transform.localRotation = spawnRotation;
      
      view.SetEntity(entity);

      return view;
    }
  }
}