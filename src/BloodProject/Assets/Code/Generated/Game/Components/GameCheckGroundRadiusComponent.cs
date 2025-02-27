//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCheckGroundRadius;

    public static Entitas.IMatcher<GameEntity> CheckGroundRadius {
        get {
            if (_matcherCheckGroundRadius == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CheckGroundRadius);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCheckGroundRadius = matcher;
            }

            return _matcherCheckGroundRadius;
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

    public _Scripts.Gameplay.Features.Gravity.CheckGroundRadius checkGroundRadius { get { return (_Scripts.Gameplay.Features.Gravity.CheckGroundRadius)GetComponent(GameComponentsLookup.CheckGroundRadius); } }
    public float CheckGroundRadius { get { return checkGroundRadius.Value; } }
    public bool hasCheckGroundRadius { get { return HasComponent(GameComponentsLookup.CheckGroundRadius); } }

    public GameEntity AddCheckGroundRadius(float newValue) {
        var index = GameComponentsLookup.CheckGroundRadius;
        var component = (_Scripts.Gameplay.Features.Gravity.CheckGroundRadius)CreateComponent(index, typeof(_Scripts.Gameplay.Features.Gravity.CheckGroundRadius));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceCheckGroundRadius(float newValue) {
        var index = GameComponentsLookup.CheckGroundRadius;
        var component = (_Scripts.Gameplay.Features.Gravity.CheckGroundRadius)CreateComponent(index, typeof(_Scripts.Gameplay.Features.Gravity.CheckGroundRadius));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveCheckGroundRadius() {
        RemoveComponent(GameComponentsLookup.CheckGroundRadius);
        return this;
    }
}
