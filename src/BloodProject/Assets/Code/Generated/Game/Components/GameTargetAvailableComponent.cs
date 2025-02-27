//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherTargetAvailable;

    public static Entitas.IMatcher<GameEntity> TargetAvailable {
        get {
            if (_matcherTargetAvailable == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TargetAvailable);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTargetAvailable = matcher;
            }

            return _matcherTargetAvailable;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly _Scripts.Gameplay.Features.Enemies.TargetAvailable targetAvailableComponent = new _Scripts.Gameplay.Features.Enemies.TargetAvailable();

    public bool isTargetAvailable {
        get { return HasComponent(GameComponentsLookup.TargetAvailable); }
        set {
            if (value != isTargetAvailable) {
                var index = GameComponentsLookup.TargetAvailable;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : targetAvailableComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
