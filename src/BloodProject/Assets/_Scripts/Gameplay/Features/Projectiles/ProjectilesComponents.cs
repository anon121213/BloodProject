using System.Collections.Generic;
using Entitas;
using Gameplay.Features.Effects.Data;

namespace Gameplay.Features.Projectiles
{
  [Game] public class Projectile : IComponent { }
  [Game] public class SimpleBulletProjectile : IComponent { }
  [Game] public class EffectSetupsComponent : IComponent { public List<EffectSetup> Value; }
}