using Entitas;

namespace _Scripts.Gameplay.Features.Enemies.Systems
{
  public class BehaviourTreeSystem : IExecuteSystem
  {
    private readonly GameEntity[] _enemies;

    public BehaviourTreeSystem(GameContext gameContext)
    {
      _enemies = gameContext.GetEntities(GameMatcher
        .AllOf(
          GameMatcher.Enemy,
          GameMatcher.BehaviourTree,
          GameMatcher.RootNode
        ));
    }

    public void Execute()
    {
      foreach (var enemy in _enemies) 
        enemy.RootNode.Execute(enemy);
    }
  }
}