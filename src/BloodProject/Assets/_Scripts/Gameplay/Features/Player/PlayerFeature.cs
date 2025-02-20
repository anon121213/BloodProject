using _Scripts.Gameplay.Features.Player.Systems;
using _Scripts.Infrastructure.Services.Factories.SystemsFactory;

namespace Gameplay.Features.Player
{
  public class PlayerFeature : Feature
  {
    public PlayerFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<SetPlayerInputDirectionSystem>());
    }
  }
}