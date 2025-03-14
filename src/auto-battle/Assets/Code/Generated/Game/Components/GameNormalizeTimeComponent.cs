//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherNormalizeTime;

    public static Entitas.IMatcher<GameEntity> NormalizeTime {
        get {
            if (_matcherNormalizeTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NormalizeTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNormalizeTime = matcher;
            }

            return _matcherNormalizeTime;
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

    public Code.Gameplay.Features.Animations.NormalizeTime normalizeTime { get { return (Code.Gameplay.Features.Animations.NormalizeTime)GetComponent(GameComponentsLookup.NormalizeTime); } }
    public float NormalizeTime { get { return normalizeTime.Value; } }
    public bool hasNormalizeTime { get { return HasComponent(GameComponentsLookup.NormalizeTime); } }

    public GameEntity AddNormalizeTime(float newValue) {
        var index = GameComponentsLookup.NormalizeTime;
        var component = (Code.Gameplay.Features.Animations.NormalizeTime)CreateComponent(index, typeof(Code.Gameplay.Features.Animations.NormalizeTime));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceNormalizeTime(float newValue) {
        var index = GameComponentsLookup.NormalizeTime;
        var component = (Code.Gameplay.Features.Animations.NormalizeTime)CreateComponent(index, typeof(Code.Gameplay.Features.Animations.NormalizeTime));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveNormalizeTime() {
        RemoveComponent(GameComponentsLookup.NormalizeTime);
        return this;
    }
}
