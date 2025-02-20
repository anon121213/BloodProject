using Entitas;
using UnityEngine;

namespace _Scripts.Gameplay.Features.Player.Systems
{
    public class SetPlayerInputDirectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _players;
        private readonly IGroup<InputEntity> _inputs;

        public SetPlayerInputDirectionSystem(GameContext gameContext, InputContext inputContext)
        {
            _players = gameContext.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Player,
                    GameMatcher.Direction,
                    GameMatcher.Camera)
                .NoneOf(GameMatcher.Dead));

            _inputs = inputContext.GetGroup(InputMatcher.Input);
        }

        public void Execute()
        {
            foreach (var input in _inputs)
            {
                foreach (var player in _players)
                {
                    player.isMoving = input.hasMoveInputAxis;

                    if (!input.hasMoveInputAxis) 
                        continue;

                    Transform cameraTransform = player.Camera.transform;
                    Vector3 moveInput = input.MoveInputAxis;

                    Vector3 cameraForward = cameraTransform.forward;
                    Vector3 cameraRight = cameraTransform.right;
                    
                    cameraForward.y = 0;
                    cameraRight.y = 0;
                    cameraForward.Normalize();
                    cameraRight.Normalize();

                    Vector3 moveDirection = (cameraForward * moveInput.z + cameraRight * moveInput.x).normalized;
                    
                    Vector3 surfaceNormal = GetSurfaceNormal(player.WorldPosition);

                    if (surfaceNormal == Vector3.zero)
                        continue;
                    
                    Vector3 adjustedDirection = Vector3.ProjectOnPlane(moveDirection, surfaceNormal).normalized;

                    player.ReplaceDirection(adjustedDirection);
                }
            }
        }

        private Vector3 GetSurfaceNormal(Vector3 position) =>
            Physics.Raycast(position + Vector3.up, Vector3.down, 
                out var hit, 2f, LayerMask.GetMask("Ground")) ? hit.normal : Vector3.up;
    }
}
