//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAnimationCurrentTime;

    public static Entitas.IMatcher<GameEntity> AnimationCurrentTime {
        get {
            if (_matcherAnimationCurrentTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnimationCurrentTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnimationCurrentTime = matcher;
            }

            return _matcherAnimationCurrentTime;
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

    public Code.Gameplay.Features.Animations.AnimationCurrentTime animationCurrentTime { get { return (Code.Gameplay.Features.Animations.AnimationCurrentTime)GetComponent(GameComponentsLookup.AnimationCurrentTime); } }
    public float AnimationCurrentTime { get { return animationCurrentTime.Value; } }
    public bool hasAnimationCurrentTime { get { return HasComponent(GameComponentsLookup.AnimationCurrentTime); } }

    public GameEntity AddAnimationCurrentTime(float newValue) {
        var index = GameComponentsLookup.AnimationCurrentTime;
        var component = (Code.Gameplay.Features.Animations.AnimationCurrentTime)CreateComponent(index, typeof(Code.Gameplay.Features.Animations.AnimationCurrentTime));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceAnimationCurrentTime(float newValue) {
        var index = GameComponentsLookup.AnimationCurrentTime;
        var component = (Code.Gameplay.Features.Animations.AnimationCurrentTime)CreateComponent(index, typeof(Code.Gameplay.Features.Animations.AnimationCurrentTime));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveAnimationCurrentTime() {
        RemoveComponent(GameComponentsLookup.AnimationCurrentTime);
        return this;
    }
}
