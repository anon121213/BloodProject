using _Scripts.Infrastructure.StateMachine;
using _Scripts.Infrastructure.StateMachine.States;
using UnityEngine;
using VContainer.Unity;

namespace _Scripts.Infrastructure.Bootstrapper
{
  public class Bootstrapper : IInitializable
  {
    private readonly IGameStateMachine _gameStateMachine;

    public Bootstrapper(IGameStateMachine gameStateMachine)
    {
      _gameStateMachine = gameStateMachine;
    }

    public void Initialize()
    {
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;

      Application.targetFrameRate = 240;
      _gameStateMachine.Enter<BootstrapState>();
    }
  }
}