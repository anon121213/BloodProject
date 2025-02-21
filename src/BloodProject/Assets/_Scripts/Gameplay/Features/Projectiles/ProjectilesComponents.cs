using System.Collections.Generic;
using _Scripts.Gameplay.Features.Projectiles.Data;
using Entitas;
using Gameplay.Features.Effects.Data;

namespace _Scripts.Gameplay.Features.Projectiles
{
  [Game] public class Projectile : IComponent { }
  [Game] public class SimpleBulletProjectile : IComponent { }
  [Game] public class EffectSetupsComponent : IComponent { public List<EffectSetup> Value; }
  [Game] public class ProjectileDataComponent : IComponent { public ProjectileData Value; }
}