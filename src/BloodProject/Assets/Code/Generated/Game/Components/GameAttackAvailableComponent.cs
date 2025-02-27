//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAttackAvailable;

    public static Entitas.IMatcher<GameEntity> AttackAvailable {
        get {
            if (_matcherAttackAvailable == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AttackAvailable);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAttackAvailable = matcher;
            }

            return _matcherAttackAvailable;
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

    static readonly _Scripts.Gameplay.Features.Weapon.WeaponComponents.AttackAvailable attackAvailableComponent = new _Scripts.Gameplay.Features.Weapon.WeaponComponents.AttackAvailable();

    public bool isAttackAvailable {
        get { return HasComponent(GameComponentsLookup.AttackAvailable); }
        set {
            if (value != isAttackAvailable) {
                var index = GameComponentsLookup.AttackAvailable;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : attackAvailableComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
