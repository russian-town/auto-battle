//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMoveToTargetAnimation;

    public static Entitas.IMatcher<GameEntity> MoveToTargetAnimation {
        get {
            if (_matcherMoveToTargetAnimation == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MoveToTargetAnimation);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMoveToTargetAnimation = matcher;
            }

            return _matcherMoveToTargetAnimation;
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

    static readonly Code.Gameplay.Features.Animations.MoveToTargetAnimation moveToTargetAnimationComponent = new Code.Gameplay.Features.Animations.MoveToTargetAnimation();

    public bool isMoveToTargetAnimation {
        get { return HasComponent(GameComponentsLookup.MoveToTargetAnimation); }
        set {
            if (value != isMoveToTargetAnimation) {
                var index = GameComponentsLookup.MoveToTargetAnimation;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : moveToTargetAnimationComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
