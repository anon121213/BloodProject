using Entitas;

namespace _Scripts.Gameplay.Features.Death
{
  [Game] public class Dead : IComponent { }
  [Game] public class DeathProcessing : IComponent { }
  [Game] public class CurrentHealth : IComponent { public float Value; }
  [Game] public class MaxHealth : IComponent { public float Value; }
  [Game] public class DestructDelay : IComponent { public float Value; }
}