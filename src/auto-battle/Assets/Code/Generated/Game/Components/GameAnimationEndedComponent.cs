//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAnimationEnded;

    public static Entitas.IMatcher<GameEntity> AnimationEnded {
        get {
            if (_matcherAnimationEnded == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnimationEnded);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnimationEnded = matcher;
            }

            return _matcherAnimationEnded;
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

    static readonly Code.Gameplay.Features.Animations.AnimationEnded animationEndedComponent = new Code.Gameplay.Features.Animations.AnimationEnded();

    public bool isAnimationEnded {
        get { return HasComponent(GameComponentsLookup.AnimationEnded); }
        set {
            if (value != isAnimationEnded) {
                var index = GameComponentsLookup.AnimationEnded;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : animationEndedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}