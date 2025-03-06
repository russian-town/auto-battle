//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherNormalizedTime;

    public static Entitas.IMatcher<GameEntity> NormalizedTime {
        get {
            if (_matcherNormalizedTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NormalizedTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNormalizedTime = matcher;
            }

            return _matcherNormalizedTime;
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

    public Code.Gameplay.Features.Animations.NormalizedTime normalizedTime { get { return (Code.Gameplay.Features.Animations.NormalizedTime)GetComponent(GameComponentsLookup.NormalizedTime); } }
    public float NormalizedTime { get { return normalizedTime.Value; } }
    public bool hasNormalizedTime { get { return HasComponent(GameComponentsLookup.NormalizedTime); } }

    public GameEntity AddNormalizedTime(float newValue) {
        var index = GameComponentsLookup.NormalizedTime;
        var component = (Code.Gameplay.Features.Animations.NormalizedTime)CreateComponent(index, typeof(Code.Gameplay.Features.Animations.NormalizedTime));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceNormalizedTime(float newValue) {
        var index = GameComponentsLookup.NormalizedTime;
        var component = (Code.Gameplay.Features.Animations.NormalizedTime)CreateComponent(index, typeof(Code.Gameplay.Features.Animations.NormalizedTime));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveNormalizedTime() {
        RemoveComponent(GameComponentsLookup.NormalizedTime);
        return this;
    }
}
