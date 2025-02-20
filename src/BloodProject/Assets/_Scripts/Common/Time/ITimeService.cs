using System;

namespace _Scripts.Common.Time
{
  public interface ITimeService
  {
    float DeltaTime { get; }
    float FixedDeltaTime { get; }
    DateTime UtcNow { get; }
    void StopTime();
    void StartTime();
  }
}