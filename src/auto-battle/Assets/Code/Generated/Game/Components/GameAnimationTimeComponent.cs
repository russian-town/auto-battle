//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAnimationTime;

    public static Entitas.IMatcher<GameEntity> AnimationTime {
        get {
            if (_matcherAnimationTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnimationTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnimationTime = matcher;
            }

            return _matcherAnimationTime;
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

    public Code.Gameplay.Features.Animations.AnimationTime animationTime { get { return (Code.Gameplay.Features.Animations.AnimationTime)GetComponent(GameComponentsLookup.AnimationTime); } }
    public float AnimationTime { get { return animationTime.Value; } }
    public bool hasAnimationTime { get { return HasComponent(GameComponentsLookup.AnimationTime); } }

    public GameEntity AddAnimationTime(float newValue) {
        var index = GameComponentsLookup.AnimationTime;
        var component = (Code.Gameplay.Features.Animations.AnimationTime)CreateComponent(index, typeof(Code.Gameplay.Features.Animations.AnimationTime));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceAnimationTime(float newValue) {
        var index = GameComponentsLookup.AnimationTime;
        var component = (Code.Gameplay.Features.Animations.AnimationTime)CreateComponent(index, typeof(Code.Gameplay.Features.Animations.AnimationTime));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveAnimationTime() {
        RemoveComponent(GameComponentsLookup.AnimationTime);
        return this;
    }
}
