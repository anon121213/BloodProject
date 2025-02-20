using _Scripts.Infrastructure.View;
using Entitas;
using UnityEngine.AddressableAssets;

namespace _Scripts.Common
{
  [Game] public class Destructed : IComponent { }
  
  [Game] public class Dead : IComponent { }
  [Game] public class Processed : IComponent { }
  
  [Game] public class View : IComponent { public IEntityView Value; }
  [Game] public class AddedView : IComponent { }
  [Game] public class ViewPath : IComponent { public string Value; }
  [Game] public class ViewReference : IComponent { public AssetReferenceGameObject Value; }
  [Game] public class ViewPrefab : IComponent { public EntityBehaviour Value; }
  [Game] public class SelfDestructTimer : IComponent { public float Value; }
  [Game] public class Owner : IComponent { public int Value; }
  [Game] public class Radius : IComponent { public float Value; }
}