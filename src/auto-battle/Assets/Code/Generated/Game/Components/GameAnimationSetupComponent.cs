//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAnimationSetup;

    public static Entitas.IMatcher<GameEntity> AnimationSetup {
        get {
            if (_matcherAnimationSetup == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnimationSetup);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnimationSetup = matcher;
            }

            return _matcherAnimationSetup;
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

    public Code.Gameplay.Features.Motions.AnimationSetupComponent animationSetup { get { return (Code.Gameplay.Features.Motions.AnimationSetupComponent)GetComponent(GameComponentsLookup.AnimationSetup); } }
    public Code.Gameplay.Features.Animations.Configs.AnimationSetup AnimationSetup { get { return animationSetup.Value; } }
    public bool hasAnimationSetup { get { return HasComponent(GameComponentsLookup.AnimationSetup); } }

    public GameEntity AddAnimationSetup(Code.Gameplay.Features.Animations.Configs.AnimationSetup newValue) {
        var index = GameComponentsLookup.AnimationSetup;
        var component = (Code.Gameplay.Features.Motions.AnimationSetupComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Motions.AnimationSetupComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceAnimationSetup(Code.Gameplay.Features.Animations.Configs.AnimationSetup newValue) {
        var index = GameComponentsLookup.AnimationSetup;
        var component = (Code.Gameplay.Features.Motions.AnimationSetupComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Motions.AnimationSetupComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveAnimationSetup() {
        RemoveComponent(GameComponentsLookup.AnimationSetup);
        return this;
    }
}
