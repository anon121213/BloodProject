namespace _Scripts.Infrastructure.Services.Identifiers
{
  public static class IdentifierService
  {
    private static int _lastId = 1;

    public static int Next() =>
      ++_lastId;
  }
}