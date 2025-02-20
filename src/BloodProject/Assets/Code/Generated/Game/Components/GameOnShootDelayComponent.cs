//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherOnShootDelay;

    public static Entitas.IMatcher<GameEntity> OnShootDelay {
        get {
            if (_matcherOnShootDelay == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.OnShootDelay);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherOnShootDelay = matcher;
            }

            return _matcherOnShootDelay;
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

    static readonly _Scripts.Gameplay.Features.Weapon.WeaponComponents.OnShootDelay onShootDelayComponent = new _Scripts.Gameplay.Features.Weapon.WeaponComponents.OnShootDelay();

    public bool isOnShootDelay {
        get { return HasComponent(GameComponentsLookup.OnShootDelay); }
        set {
            if (value != isOnShootDelay) {
                var index = GameComponentsLookup.OnShootDelay;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : onShootDelayComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
