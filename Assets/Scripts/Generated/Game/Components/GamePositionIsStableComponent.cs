//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Osnowa.Osnowa.Example.ECS.Presence.PositionIsStable positionIsStableComponent = new Osnowa.Osnowa.Example.ECS.Presence.PositionIsStable();

    public bool isPositionIsStable {
        get { return HasComponent(GameComponentsLookup.PositionIsStable); }
        set {
            if (value != isPositionIsStable) {
                var index = GameComponentsLookup.PositionIsStable;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : positionIsStableComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPositionIsStable;

    public static Entitas.IMatcher<GameEntity> PositionIsStable {
        get {
            if (_matcherPositionIsStable == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PositionIsStable);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPositionIsStable = matcher;
            }

            return _matcherPositionIsStable;
        }
    }
}