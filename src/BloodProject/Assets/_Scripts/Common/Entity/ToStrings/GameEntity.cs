using System;
using System.Linq;
using System.Text;
using _Scripts.Common.Entity.ToStrings;
using _Scripts.Common.Extensions;
using _Scripts.Gameplay.Features.Player;
using Entitas;
using Gameplay.Features.Player;
using UnityEngine;

// ReSharper disable once CheckNamespace
public sealed partial class GameEntity : INamedEntity
{
  private EntityPrinter _printer;

  public override string ToString()
  {
    if (_printer == null)
      _printer = new EntityPrinter(this);

    _printer.InvalidateCache();

    return _printer.BuildToString();
  }

  public string EntityName(IComponent[] components)
  {
    try
    {
      if (components.Length == 1)
        return components[0].GetType().Name;

      foreach (IComponent component in components)
      {
        switch (component.GetType().Name)
        {
          case nameof(Player):
            return PrintHero();
        }
      }
    }
    catch (Exception exception)
    {
      Debug.LogError(exception.Message);
    }

    return components.First().GetType().Name;
  }

  private string PrintHero() =>
    new StringBuilder($"Player ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();

  private string PrintEnemy() =>
    new StringBuilder($"Enemy ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();
  
    private string PrintWeapon() =>
    new StringBuilder($"Weapon ")
      .With(s => s.Append($"Id:{Id}"), when: hasId)
      .ToString();
  
  public string BaseToString() => base.ToString();
}

