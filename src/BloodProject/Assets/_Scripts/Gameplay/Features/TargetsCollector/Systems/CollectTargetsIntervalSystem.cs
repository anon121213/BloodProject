using _Scripts.Common.Time;
using Entitas;

namespace Gameplay.Features.TargetsCollector.Systems
{
  public class CollectTargetsIntervalSystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _collectors;

    public CollectTargetsIntervalSystem(GameContext gameContext, ITimeService timeService)
    {
      _timeService = timeService;
      _collectors = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.CollectTargetsTimer,
          GameMatcher.CollectTargetsInterval
        ));
    }

    public void Execute()
    {
      foreach (var collector in _collectors)
      {
        collector.ReplaceCollectTargetsTimer(collector.CollectTargetsTimer - _timeService.DeltaTime);

        if (collector.CollectTargetsTimer <= 0)
        {
          collector.isReadyToCollectTargets = true;
          collector.ReplaceCollectTargetsTimer(collector.CollectTargetsInterval);
        }
      }
    }
  }
}