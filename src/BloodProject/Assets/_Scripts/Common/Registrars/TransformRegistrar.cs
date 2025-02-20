using _Scripts.Infrastructure.View.Registrars;

namespace _Scripts.Common.Registrars
{
  public class TransformRegistrar : EntityComponentRegistrar
  {
    public override void RegisterComponents()
    {
      Entity.AddTransform(transform);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasTransform)
        Entity.RemoveTransform();
    }
  }
}