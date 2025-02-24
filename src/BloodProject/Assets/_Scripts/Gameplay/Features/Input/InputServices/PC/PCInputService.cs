using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Gameplay.Features.Input.InputServices.PC
{
  public class PCInputService : IInputService, IDisposable
  {
    private readonly InputActions _playerInput;

    public Vector3 MoveDirection => _playerInput.Pc.Movement.ReadValue<Vector3>().normalized;
    public Vector2 MousePosition => _playerInput.Pc.MousePosition.ReadValue<Vector2>();
    public Vector2 MouseDelta => _playerInput.Pc.MouseDelta.ReadValue<Vector2>();

    public bool IsMoving { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsDashing { get; private set; }
    public bool IsShooting { get; private set; }
    public bool IsReloading { get; private set; }

    public PCInputService()
    {
      _playerInput = new InputActions();
      _playerInput.Enable();
      EnableInput();
    }

    public void EnableInput() => 
      RegisterInputActions(true);

    public void DisableInput() => 
      RegisterInputActions(false);

    private void RegisterInputActions(bool enable)
    {
      void RegisterAction(InputAction action, Action<InputAction.CallbackContext> start,
        Action<InputAction.CallbackContext> stop)
      {
        if (enable)
        {
          action.started += start;
          action.canceled += stop;
        }
        else
        {
          action.started -= start;
          action.canceled -= stop;
        }
      }

      RegisterAction(_playerInput.Pc.Movement, _ => IsMoving = true, _ => IsMoving = false);
      RegisterAction(_playerInput.Pc.Shooting, _ => IsShooting = true, _ => IsShooting = false);
      RegisterAction(_playerInput.Pc.Reload, _ => IsReloading = true, _ => IsReloading = false);
      RegisterAction(_playerInput.Pc.Jumping, _ => IsJumping = true, _ => IsJumping = false);
      RegisterAction(_playerInput.Pc.Dashing, _ => IsDashing = true, _ => IsDashing = false);
    }

    public void Dispose()
    {
      DisableInput();
      _playerInput.Disable();
    }
  }
}