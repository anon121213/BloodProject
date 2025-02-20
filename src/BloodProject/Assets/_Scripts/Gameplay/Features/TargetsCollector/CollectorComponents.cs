using System.Collections.Generic;
using Entitas;

namespace Gameplay.Features.TargetsCollector
{ 
  [Game] public class ReadyToCollectTargets : IComponent { }
  [Game] public class CollectTargetsContinuously : IComponent { }
  [Game] public class TargetsBuffer : IComponent { public List<int> Value; }
  [Game] public class TargetsLimit : IComponent { public float Value; }
  [Game] public class ProcessedTargets : IComponent { public List<int> Value; }
  
  [Game] public class CollectTargetsInterval : IComponent { public float Value; }
  [Game] public class CollectTargetsTimer : IComponent { public float Value; }
  
  [Game] public class LayerMask : IComponent { public int Value; }   
}