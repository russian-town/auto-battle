//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherProgressQueue;

    public static Entitas.IMatcher<GameEntity> ProgressQueue {
        get {
            if (_matcherProgressQueue == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ProgressQueue);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherProgressQueue = matcher;
            }

            return _matcherProgressQueue;
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

    public Code.Gameplay.Features.Progress.ProgressQueue progressQueue { get { return (Code.Gameplay.Features.Progress.ProgressQueue)GetComponent(GameComponentsLookup.ProgressQueue); } }
    public System.Collections.Generic.Queue<Code.Gameplay.Features.Progress.Config.ProgressSetup> ProgressQueue { get { return progressQueue.Value; } }
    public bool hasProgressQueue { get { return HasComponent(GameComponentsLookup.ProgressQueue); } }

    public GameEntity AddProgressQueue(System.Collections.Generic.Queue<Code.Gameplay.Features.Progress.Config.ProgressSetup> newValue) {
        var index = GameComponentsLookup.ProgressQueue;
        var component = (Code.Gameplay.Features.Progress.ProgressQueue)CreateComponent(index, typeof(Code.Gameplay.Features.Progress.ProgressQueue));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceProgressQueue(System.Collections.Generic.Queue<Code.Gameplay.Features.Progress.Config.ProgressSetup> newValue) {
        var index = GameComponentsLookup.ProgressQueue;
        var component = (Code.Gameplay.Features.Progress.ProgressQueue)CreateComponent(index, typeof(Code.Gameplay.Features.Progress.ProgressQueue));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveProgressQueue() {
        RemoveComponent(GameComponentsLookup.ProgressQueue);
        return this;
    }
}
