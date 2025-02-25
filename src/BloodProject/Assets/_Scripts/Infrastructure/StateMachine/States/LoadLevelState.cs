using System.Collections.Generic;
using _Scripts.Gameplay.Features.Enemies.BehaviourTree.Base;
using _Scripts.Gameplay.Features.Enemies.BehaviourTree.Nodes;
using _Scripts.Gameplay.Features.Enemies.Data;
using _Scripts.Gameplay.Features.Enemies.Factory;
using _Scripts.Infrastructure.Constants;
using _Scripts.Infrastructure.Services.SceneLoader;
using _Scripts.Infrastructure.Services.StaticData.Provider;
using _Scripts.Infrastructure.StateMachine.StateInfrastructure;
using Gameplay.Features.Player.Factory;
using UnityEngine;

namespace _Scripts.Infrastructure.StateMachine.States
{
  public class LoadLevelState : SimpleState
  {
    private readonly ISceneLoader _sceneLoader;
    private readonly IPlayerFactory _playerFactory;
    private readonly IEnemyFactory _enemyFactory;
    private readonly PatrolNode _patrolNode;
    private readonly MoveToPlayerNode _moveToPlayerNode;
    private readonly AttackNode _attackNode;
    private readonly IStaticDataProvider _staticDataProvider;
    private readonly IGameStateMachine _gameStateMachine;

    private UpdateFeature _updateFeature;

    public LoadLevelState(ISceneLoader sceneLoader,
      IStaticDataProvider staticDataProvider,
      IGameStateMachine gameStateMachine,
      IPlayerFactory playerFactory,
      IEnemyFactory enemyFactory,
      PatrolNode patrolNode,
      MoveToPlayerNode moveToPlayerNode,
      AttackNode attackNode)
    {
      _sceneLoader = sceneLoader;
      _playerFactory = playerFactory;
      _enemyFactory = enemyFactory;
      _patrolNode = patrolNode;
      _moveToPlayerNode = moveToPlayerNode;
      _attackNode = attackNode;
      _staticDataProvider = staticDataProvider;
      _gameStateMachine = gameStateMachine;
    }

    public override async void Enter()
    {
      await _sceneLoader.Load(SceneConstants.GameSceneName);

      Node enemyRootNode = new SelectorNode(new List<Node>
      {
        new SequenceNode(new List<Node>
        {
          _moveToPlayerNode,
          _attackNode
        }),
        _patrolNode
      });

      _playerFactory.CreatePlayer(_staticDataProvider.PlayerSettings.SpawnPosition);
      _enemyFactory.CreateEnemy(EnemyType.SimpleEnemy, new Vector3(0, 2, 10), enemyRootNode);
      _gameStateMachine.Enter<GameLoopState>();
    }
  }
}