using System.Collections.Generic;
using _Scripts.Infrastructure.View.Factory;
using Entitas;
using UnityEngine;

namespace _Scripts.Infrastructure.View.Systems
{
  public class BindEntityViewFromPathSystem : IExecuteSystem
  {
    private readonly IEntityViewFactory _entityViewFactory;
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(64);

    public BindEntityViewFromPathSystem(GameContext game, IEntityViewFactory entityViewFactory)
    {
      _entityViewFactory = entityViewFactory;
      _entities = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.ViewReference)
        .NoneOf(GameMatcher.View));
    }

    public async void Execute()
    {
      _entities.GetEntities(_buffer);

      for (int i = 0; i < _buffer.Count; i++)
      {
        if (_buffer[i].hasView || _buffer[i].isAddedView)
          continue;

        _buffer[i].isAddedView = true;

        if (_buffer[i].hasViewRoot)
          await _entityViewFactory.CreateViewForEntity(_buffer[i], _buffer[i].ViewRoot);
        else
          await _entityViewFactory.CreateViewForEntity(_buffer[i], null);
      }

      _buffer.Clear();
    }
  }
}