using _Scripts.Common.Time;
using Entitas;

namespace _Scripts.Gameplay.Features.Movement.System
{
  public class MoveCharacterControllerByDirectionSystem : IExecuteSystem
  {
    private readonly ITimeService _time;
    private readonly IGroup<GameEntity> _movers;
      
    public MoveCharacterControllerByDirectionSystem(GameContext gameContext, ITimeService timeService)
    {
      _time = timeService;
      _movers = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Direction,
          GameMatcher.Speed,
          GameMatcher.MovementAvailable,
          GameMatcher.CharacterController,
          GameMatcher.MoveByPhysic
        ));
    }
    
    public void Execute()
    {
      foreach (var mover in _movers)
        if (mover.isMoving) 
          mover.CharacterController.Move(mover.Direction * mover.Speed * _time.DeltaTime);
    }
  }
}