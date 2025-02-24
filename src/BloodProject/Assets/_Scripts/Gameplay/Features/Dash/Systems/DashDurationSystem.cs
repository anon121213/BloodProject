using System.Collections.Generic;
using _Scripts.Common.Time;
using Entitas;

namespace _Scripts.Gameplay.Features.Dash.Systems
{
  public class DashDurationSystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IGroup<GameEntity> _players;
    private readonly List<GameEntity> _buffer = new(16);

    public DashDurationSystem(GameContext gameContext, ITimeService timeService)
    {
      _timeService = timeService;
      _players = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Dashing,
          GameMatcher.DashDuration,
          GameMatcher.CurrentDashDuration
        ));
    }

    public void Execute()
    {
      foreach (var player in _players.GetEntities(_buffer))
      {
        if (player.isOnStartDash)
        {
          player.ReplaceCurrentDashDuration(0);
          player.isOnStartDash = false;
        }

        player.ReplaceCurrentDashDuration(player.CurrentDashDuration + _timeService.DeltaTime);

        if (player.CurrentDashDuration >= player.DashDuration)
        {
          player.isDashing = false;
        }
      }
    }
  }
}