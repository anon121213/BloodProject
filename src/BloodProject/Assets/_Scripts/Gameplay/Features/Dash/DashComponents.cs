using Entitas;

namespace _Scripts.Gameplay.Features.Dash
{
  [Game] public class DashAvailable : IComponent { }
  [Game] public class OnDashCooldown : IComponent { }
  [Game] public class OnStartDash : IComponent { }
  [Game] public class OnEndDash : IComponent { }
  [Game] public class Dashing : IComponent { }
  [Game] public class DashDistance : IComponent { public float Value; }
  [Game] public class DashDuration : IComponent { public float Value; }
  [Game] public class CurrentDashDuration : IComponent { public float Value; }
  [Game] public class DashCooldown : IComponent { public float Value; }
  [Game] public class CurrentDashCooldown : IComponent { public float Value; }
}