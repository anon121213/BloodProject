//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCurrentDashDuration;

    public static Entitas.IMatcher<GameEntity> CurrentDashDuration {
        get {
            if (_matcherCurrentDashDuration == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentDashDuration);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentDashDuration = matcher;
            }

            return _matcherCurrentDashDuration;
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

    public _Scripts.Gameplay.Features.Dash.CurrentDashDuration currentDashDuration { get { return (_Scripts.Gameplay.Features.Dash.CurrentDashDuration)GetComponent(GameComponentsLookup.CurrentDashDuration); } }
    public float CurrentDashDuration { get { return currentDashDuration.Value; } }
    public bool hasCurrentDashDuration { get { return HasComponent(GameComponentsLookup.CurrentDashDuration); } }

    public GameEntity AddCurrentDashDuration(float newValue) {
        var index = GameComponentsLookup.CurrentDashDuration;
        var component = (_Scripts.Gameplay.Features.Dash.CurrentDashDuration)CreateComponent(index, typeof(_Scripts.Gameplay.Features.Dash.CurrentDashDuration));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceCurrentDashDuration(float newValue) {
        var index = GameComponentsLookup.CurrentDashDuration;
        var component = (_Scripts.Gameplay.Features.Dash.CurrentDashDuration)CreateComponent(index, typeof(_Scripts.Gameplay.Features.Dash.CurrentDashDuration));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveCurrentDashDuration() {
        RemoveComponent(GameComponentsLookup.CurrentDashDuration);
        return this;
    }
}
