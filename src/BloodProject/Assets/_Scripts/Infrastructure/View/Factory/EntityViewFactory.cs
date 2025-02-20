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
    private readonly Vector3 _farAway = new(-999, 999, 0);

    public EntityViewFactory(IAssetProvider assetProvider,
      IObjectResolver resolver)
    {
      _assetProvider = assetProvider;
      _resolver = resolver;
    }
    
    public async UniTask<EntityBehaviour> CreateViewForEntity(GameEntity entity)
    {
      EntityBehaviour viewPrefab = await _assetProvider.LoadAsync<EntityBehaviour>(entity.ViewReference);
      
      EntityBehaviour view = _resolver.Instantiate(
        viewPrefab,
        position: _farAway,
        Quaternion.identity,
        null);
      
      view.SetEntity(entity);

      return view;
    }

    public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity)
    {
      EntityBehaviour view = _resolver.Instantiate(
        entity.ViewPrefab,
        position: _farAway,
        Quaternion.identity,null);
      
      view.SetEntity(entity);

      return view;
    }
  }
}