//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherParentInitialized;

    public static Entitas.IMatcher<GameEntity> ParentInitialized {
        get {
            if (_matcherParentInitialized == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ParentInitialized);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherParentInitialized = matcher;
            }

            return _matcherParentInitialized;
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

    static readonly Code.Gameplay.Features.Movement.ParentInitialized parentInitializedComponent = new Code.Gameplay.Features.Movement.ParentInitialized();

    public bool isParentInitialized {
        get { return HasComponent(GameComponentsLookup.ParentInitialized); }
        set {
            if (value != isParentInitialized) {
                var index = GameComponentsLookup.ParentInitialized;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : parentInitializedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}