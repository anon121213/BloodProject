using Entitas;

namespace _Scripts.Gameplay.Features.SimpleShootSystem.Systems
{
  public class SimpleShootSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _player;
    private readonly IGroup<InputEntity> _inputs;

    public SimpleShootSystem(GameContext gameContext, InputContext inputContext)
    {
      _player = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Player
        ));

      _inputs = inputContext.GetGroup(InputMatcher.AllOf(InputMatcher.Input));
    }

    public void Execute()
    {
      foreach (var input in _inputs)
      foreach (var player in _player)
      {
        if (input.isShooting) 
          player.isShoot = true;
      }
    }
  }
}