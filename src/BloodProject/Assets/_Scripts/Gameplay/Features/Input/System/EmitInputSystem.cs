using Entitas;
using Gameplay.Features.Input.InputServices;

namespace Gameplay.Features.Input.System
{
  public class EmitInputSystem : IExecuteSystem
  {
    private readonly IInputService _inputService;
    private readonly IGroup<InputEntity> _inputs;

    public EmitInputSystem(InputContext gameContext,
      IInputService inputService)
    {
      _inputService = inputService;
      _inputs = gameContext.GetGroup(InputMatcher
        .AllOf(
          InputMatcher.Input
          ));
    }

    public void Execute()
    {
      foreach (var input in _inputs)
      {
        if (_inputService.IsMoving)
          input.ReplaceMoveInputAxis(_inputService.MoveDirection);
        else if (input.hasMoveInputAxis) 
          input.RemoveMoveInputAxis();

        input.isShooting = _inputService.IsShooting;
        input.isReloading = _inputService.IsReloading;

        input.ReplaceMouseInputAxis(_inputService.MousePosition);
        input.ReplaceMouseInputDelta(_inputService.MouseDelta);
      }
    }
  }
}