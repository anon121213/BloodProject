﻿namespace Gameplay.Features.EntitiesStats.Indexing
{
  public struct StatKey
  {
    public readonly int TargetId;
    public readonly Stats Stat;

    public StatKey(int targetId, Stats stat)
    {
      TargetId = targetId;
      Stat = stat;
    }
  }
}