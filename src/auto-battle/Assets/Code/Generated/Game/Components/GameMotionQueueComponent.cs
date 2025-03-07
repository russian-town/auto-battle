//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMotionQueue;

    public static Entitas.IMatcher<GameEntity> MotionQueue {
        get {
            if (_matcherMotionQueue == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MotionQueue);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMotionQueue = matcher;
            }

            return _matcherMotionQueue;
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

    public Code.Gameplay.Features.Motions.MotionQueue motionQueue { get { return (Code.Gameplay.Features.Motions.MotionQueue)GetComponent(GameComponentsLookup.MotionQueue); } }
    public System.Collections.Generic.Queue<Code.Gameplay.Features.Motions.Configs.MotionConfig> MotionQueue { get { return motionQueue.Value; } }
    public bool hasMotionQueue { get { return HasComponent(GameComponentsLookup.MotionQueue); } }

    public GameEntity AddMotionQueue(System.Collections.Generic.Queue<Code.Gameplay.Features.Motions.Configs.MotionConfig> newValue) {
        var index = GameComponentsLookup.MotionQueue;
        var component = (Code.Gameplay.Features.Motions.MotionQueue)CreateComponent(index, typeof(Code.Gameplay.Features.Motions.MotionQueue));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceMotionQueue(System.Collections.Generic.Queue<Code.Gameplay.Features.Motions.Configs.MotionConfig> newValue) {
        var index = GameComponentsLookup.MotionQueue;
        var component = (Code.Gameplay.Features.Motions.MotionQueue)CreateComponent(index, typeof(Code.Gameplay.Features.Motions.MotionQueue));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveMotionQueue() {
        RemoveComponent(GameComponentsLookup.MotionQueue);
        return this;
    }
}
