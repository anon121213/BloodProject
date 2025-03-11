using System.Collections.Generic;
using _Scripts.Common.Time;
using Entitas;

namespace _Scripts.Gameplay.Features.Push.Systems
{
  public class PushDurationSystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _players;
    private readonly List<GameEntity> _buffer = new(16);

    public PushDurationSystem(GameContext gameContext, ITimeService timeService)
    {
      _timeService = timeService;
      _players = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Pushing,
          GameMatcher.PushDuration,
          GameMatcher.CurrentPushDuration
        ));
    }

    public void Execute()
    {
      foreach (var player in _players.GetEntities(_buffer))
      {
        if (player.isOnStartPush)
        {
          player.ReplaceCurrentPushDuration(0);
          player.isOnStartPush = false;
        }

        player.ReplaceCurrentPushDuration(player.CurrentPushDuration + _timeService.DeltaTime);

        if (player.CurrentPushDuration >= player.PushDuration)
        {
          player.isPushing = false;
        }
      }
    }
  }
}