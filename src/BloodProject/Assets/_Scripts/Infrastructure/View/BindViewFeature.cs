using _Scripts.Infrastructure.Services.Factories.SystemsFactory;
using _Scripts.Infrastructure.View.Systems;

namespace _Scripts.Infrastructure.View
{
  public sealed class BindViewFeature : Feature
  {
    public BindViewFeature(ISystemFactory systems)
    {
      Add(systems.Create<BindEntityViewFromPathSystem>());
      Add(systems.Create<BindEntityViewFromPrefabSystem>());
    }
  }
}