using Entitas;

namespace Gameplay.Features.TargetsCollector.Systems
{
  public class TargetsCleanupSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _collectors;

    public TargetsCleanupSystem(GameContext gameContext)
    {
      _collectors = gameContext.GetGroup(GameMatcher.TargetsBuffer);
    }
    
    public void Cleanup()
    {
      foreach (var collector in _collectors) 
        collector.TargetsBuffer.Clear();
    }
  }
}