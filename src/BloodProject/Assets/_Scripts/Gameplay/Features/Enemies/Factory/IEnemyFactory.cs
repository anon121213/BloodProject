using _Scripts.Gameplay.Features.Enemies.BehaviourTree.Base;
using _Scripts.Gameplay.Features.Enemies.Data;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Enemies.Factory
{
  public interface IEnemyFactory
  {
    GameEntity CreateEnemy(EnemyType type, Vector3 position, Node rootNode);
  }
}