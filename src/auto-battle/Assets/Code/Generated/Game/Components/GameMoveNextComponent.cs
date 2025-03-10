//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMoveNext;

    public static Entitas.IMatcher<GameEntity> MoveNext {
        get {
            if (_matcherMoveNext == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MoveNext);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMoveNext = matcher;
            }

            return _matcherMoveNext;
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

    static readonly Code.Gameplay.Features.AnimationsQueue.MoveNext moveNextComponent = new Code.Gameplay.Features.AnimationsQueue.MoveNext();

    public bool isMoveNext {
        get { return HasComponent(GameComponentsLookup.MoveNext); }
        set {
            if (value != isMoveNext) {
                var index = GameComponentsLookup.MoveNext;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : moveNextComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
