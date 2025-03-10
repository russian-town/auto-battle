//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEffectWindow;

    public static Entitas.IMatcher<GameEntity> EffectWindow {
        get {
            if (_matcherEffectWindow == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EffectWindow);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEffectWindow = matcher;
            }

            return _matcherEffectWindow;
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

    public Code.Gameplay.Features.Effect.EffectWindowComponent effectWindow { get { return (Code.Gameplay.Features.Effect.EffectWindowComponent)GetComponent(GameComponentsLookup.EffectWindow); } }
    public Code.Gameplay.Features.Effect.Behaviours.EffectWindow EffectWindow { get { return effectWindow.Value; } }
    public bool hasEffectWindow { get { return HasComponent(GameComponentsLookup.EffectWindow); } }

    public GameEntity AddEffectWindow(Code.Gameplay.Features.Effect.Behaviours.EffectWindow newValue) {
        var index = GameComponentsLookup.EffectWindow;
        var component = (Code.Gameplay.Features.Effect.EffectWindowComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Effect.EffectWindowComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceEffectWindow(Code.Gameplay.Features.Effect.Behaviours.EffectWindow newValue) {
        var index = GameComponentsLookup.EffectWindow;
        var component = (Code.Gameplay.Features.Effect.EffectWindowComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Effect.EffectWindowComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveEffectWindow() {
        RemoveComponent(GameComponentsLookup.EffectWindow);
        return this;
    }
}
