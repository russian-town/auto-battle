//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCurrentTime;

    public static Entitas.IMatcher<GameEntity> CurrentTime {
        get {
            if (_matcherCurrentTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentTime = matcher;
            }

            return _matcherCurrentTime;
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

    public Code.Gameplay.Features.Animations.CurrentTime currentTime { get { return (Code.Gameplay.Features.Animations.CurrentTime)GetComponent(GameComponentsLookup.CurrentTime); } }
    public float CurrentTime { get { return currentTime.Value; } }
    public bool hasCurrentTime { get { return HasComponent(GameComponentsLookup.CurrentTime); } }

    public GameEntity AddCurrentTime(float newValue) {
        var index = GameComponentsLookup.CurrentTime;
        var component = (Code.Gameplay.Features.Animations.CurrentTime)CreateComponent(index, typeof(Code.Gameplay.Features.Animations.CurrentTime));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceCurrentTime(float newValue) {
        var index = GameComponentsLookup.CurrentTime;
        var component = (Code.Gameplay.Features.Animations.CurrentTime)CreateComponent(index, typeof(Code.Gameplay.Features.Animations.CurrentTime));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveCurrentTime() {
        RemoveComponent(GameComponentsLookup.CurrentTime);
        return this;
    }
}
