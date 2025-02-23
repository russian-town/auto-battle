//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHitAnimation;

    public static Entitas.IMatcher<GameEntity> HitAnimation {
        get {
            if (_matcherHitAnimation == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HitAnimation);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHitAnimation = matcher;
            }

            return _matcherHitAnimation;
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

    static readonly Code.Gameplay.Features.Animations.HitAnimation hitAnimationComponent = new Code.Gameplay.Features.Animations.HitAnimation();

    public bool isHitAnimation {
        get { return HasComponent(GameComponentsLookup.HitAnimation); }
        set {
            if (value != isHitAnimation) {
                var index = GameComponentsLookup.HitAnimation;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : hitAnimationComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
