//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherOnStartDash;

    public static Entitas.IMatcher<GameEntity> OnStartDash {
        get {
            if (_matcherOnStartDash == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.OnStartDash);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherOnStartDash = matcher;
            }

            return _matcherOnStartDash;
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

    static readonly _Scripts.Gameplay.Features.Dash.OnStartDash onStartDashComponent = new _Scripts.Gameplay.Features.Dash.OnStartDash();

    public bool isOnStartDash {
        get { return HasComponent(GameComponentsLookup.OnStartDash); }
        set {
            if (value != isOnStartDash) {
                var index = GameComponentsLookup.OnStartDash;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : onStartDashComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
