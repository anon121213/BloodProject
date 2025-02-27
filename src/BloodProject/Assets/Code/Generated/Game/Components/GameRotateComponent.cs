//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRotate;

    public static Entitas.IMatcher<GameEntity> Rotate {
        get {
            if (_matcherRotate == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Rotate);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRotate = matcher;
            }

            return _matcherRotate;
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

    static readonly _Scripts.Gameplay.Features.Movement.Rotate rotateComponent = new _Scripts.Gameplay.Features.Movement.Rotate();

    public bool isRotate {
        get { return HasComponent(GameComponentsLookup.Rotate); }
        set {
            if (value != isRotate) {
                var index = GameComponentsLookup.Rotate;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : rotateComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
