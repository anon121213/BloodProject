using System.Collections.Generic;
using _Scripts.Gameplay.Features.Effects.Data;
using _Scripts.Gameplay.Features.Projectiles.Data;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Projectiles
{
  [Game] public class Projectile : IComponent { }
  [Game] public class TeleportProjectile : IComponent { }
  [Game] public class SimpleBulletProjectile : IComponent { }
  [Game] public class TeleportProjectileEndPoint : IComponent { public Vector3 Value; }
  [Game] public class EffectSetupsComponent : IComponent { public List<EffectSetup> Value; }
  [Game] public class ProjectileDataComponent : IComponent { public ProjectileConfig Value; }
}