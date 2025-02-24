using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Player.Systems
{
  public class SetPlayerInputDirectionSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _players;
    private readonly IGroup<InputEntity> _inputs;

    private readonly float _smoothSpeed = 30f;  // скорость интерполяции
    private Vector3 _currentDirection = Vector3.zero;

    public SetPlayerInputDirectionSystem(GameContext gameContext, InputContext inputContext)
    {
      _players = gameContext.GetGroup(
        GameMatcher.AllOf(
            GameMatcher.Player,
            GameMatcher.Direction,
            GameMatcher.Camera,
            GameMatcher.MovementAvailable,
            GameMatcher.IgnoreGroundLayers)
          .NoneOf(GameMatcher.Dead));

      _inputs = inputContext.GetGroup(InputMatcher.Input);
    }

    public void Execute()
    {
      foreach (var input in _inputs)
      {
        foreach (var player in _players)
        {
          player.isMoving = true;

          Transform cameraTransform = player.Camera.transform;
          Vector3 moveInput = input.hasMoveInputAxis ? input.MoveInputAxis : Vector3.zero;

          Vector3 cameraForward = cameraTransform.forward;
          Vector3 cameraRight = cameraTransform.right;

          cameraForward.y = 0;
          cameraRight.y = 0;
          cameraForward.Normalize();
          cameraRight.Normalize();

          Vector3 moveDirection = (cameraForward * moveInput.z + cameraRight * moveInput.x).normalized;

          Vector3 surfaceNormal = GetSurfaceNormal(player.WorldPosition, player.IgnoreGroundLayers);

          if (surfaceNormal == Vector3.zero)
            continue;

          Vector3 adjustedDirection = Vector3.ProjectOnPlane(moveDirection, surfaceNormal).normalized;

          // Плавно изменяем направление с использованием интерполяции
          _currentDirection = moveInput == Vector3.zero ? Vector3.zero : Vector3.Slerp(_currentDirection, adjustedDirection, Time.deltaTime * _smoothSpeed);

          player.ReplaceDirection(_currentDirection);
        }
      }
    }

    private Vector3 GetSurfaceNormal(Vector3 position, LayerMask layers) =>
      Physics.Raycast(position + Vector3.up, Vector3.down,
        out var hit, 2f, ~layers)
        ? hit.normal
        : Vector3.up;
  }
}
