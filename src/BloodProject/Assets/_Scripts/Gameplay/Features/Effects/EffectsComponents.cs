using Entitas;

namespace Gameplay.Features.Effects
{
  [Game] public class CurrentHealth : IComponent { public float Value; }
  [Game] public class MaxHealth : IComponent { public float Value; }
  
  [Game] public class Effect : IComponent { }
  [Game] public class ProducerId : IComponent { public int Value; }
  [Game] public class TargetId : IComponent { public int Value; }
  [Game] public class EffectValue : IComponent { public float Value; }
  
  [Game] public class DamageEffect : IComponent { }
  [Game] public class PushEffect : IComponent { }
}