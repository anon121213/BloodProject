using _Scripts.Gameplay.Features.Blood.Data;
using Entitas;
using Knife.RealBlood;
using UnityEngine.AddressableAssets;

namespace _Scripts.Gameplay.Features.Blood
{
  [Game] public class BloodHittableEntity : IComponent { }
  [Game] public class HitBoxes : IComponent { public HitBox[] Value; }
  [Game] public class BloodHitPrefab : IComponent { public AssetReferenceGameObject Value; }
  [Game] public class BloodFlowPrefab : IComponent { public AssetReferenceGameObject Value; }
  [Game] public class BloodDataComponent : IComponent { public BloodData Value; }
}