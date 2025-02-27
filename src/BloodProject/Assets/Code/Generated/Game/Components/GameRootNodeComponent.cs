//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRootNode;

    public static Entitas.IMatcher<GameEntity> RootNode {
        get {
            if (_matcherRootNode == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RootNode);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRootNode = matcher;
            }

            return _matcherRootNode;
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

    public _Scripts.Gameplay.Features.Enemies.RootNode rootNode { get { return (_Scripts.Gameplay.Features.Enemies.RootNode)GetComponent(GameComponentsLookup.RootNode); } }
    public _Scripts.Gameplay.Features.Enemies.BehaviourTree.Base.Node RootNode { get { return rootNode.Value; } }
    public bool hasRootNode { get { return HasComponent(GameComponentsLookup.RootNode); } }

    public GameEntity AddRootNode(_Scripts.Gameplay.Features.Enemies.BehaviourTree.Base.Node newValue) {
        var index = GameComponentsLookup.RootNode;
        var component = (_Scripts.Gameplay.Features.Enemies.RootNode)CreateComponent(index, typeof(_Scripts.Gameplay.Features.Enemies.RootNode));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceRootNode(_Scripts.Gameplay.Features.Enemies.BehaviourTree.Base.Node newValue) {
        var index = GameComponentsLookup.RootNode;
        var component = (_Scripts.Gameplay.Features.Enemies.RootNode)CreateComponent(index, typeof(_Scripts.Gameplay.Features.Enemies.RootNode));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveRootNode() {
        RemoveComponent(GameComponentsLookup.RootNode);
        return this;
    }
}
