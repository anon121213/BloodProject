using _Scripts.Common.Time;
using _Scripts.Infrastructure.Services.StaticData.Provider;
using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Camera.Systems
{
  public class CameraRotateByMouseSystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IStaticDataProvider _staticDataProvider;
    private readonly IGroup<InputEntity> _inputs;
    private readonly IGroup<GameEntity> _player;

    private float _xRotation;

    public CameraRotateByMouseSystem(InputContext inputContext,
      GameContext gameContext,
      ITimeService timeService,
      IStaticDataProvider staticDataProvider)
    {
      _inputs = inputContext.GetGroup(InputMatcher.Input);
      _player = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Player,
          GameMatcher.Transform,
          GameMatcher.Camera,
          GameMatcher.Model
        ));

      _timeService = timeService;
      _staticDataProvider = staticDataProvider;
    }

    public void Execute()
    {
      foreach (var player in _player)
      foreach (var input in _inputs)
      {
        Rotate(player, input.MouseInputDelta.x, input.MouseInputDelta.y, _staticDataProvider.CameraSettings.Sensitivity);
      }
    }

    private void Rotate(GameEntity player, float xAxis, float yAxis, float sensitivity)
    {
      float mouseX = xAxis * sensitivity * _timeService.DeltaTime;
      float mouseY = yAxis * sensitivity * _timeService.DeltaTime;

      _xRotation -= mouseY;
      _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

      Transform modelTransform = player.Model;
      modelTransform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
      
      Transform playerTransform = player.Transform;
      playerTransform.Rotate(Vector3.up * mouseX);
    }
  }
}