//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAnimatorId;

    public static Entitas.IMatcher<GameEntity> AnimatorId {
        get {
            if (_matcherAnimatorId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnimatorId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnimatorId = matcher;
            }

            return _matcherAnimatorId;
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

    public Code.Gameplay.Features.Animations.AnimatorId animatorId { get { return (Code.Gameplay.Features.Animations.AnimatorId)GetComponent(GameComponentsLookup.AnimatorId); } }
    public int AnimatorId { get { return animatorId.Value; } }
    public bool hasAnimatorId { get { return HasComponent(GameComponentsLookup.AnimatorId); } }

    public GameEntity AddAnimatorId(int newValue) {
        var index = GameComponentsLookup.AnimatorId;
        var component = (Code.Gameplay.Features.Animations.AnimatorId)CreateComponent(index, typeof(Code.Gameplay.Features.Animations.AnimatorId));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceAnimatorId(int newValue) {
        var index = GameComponentsLookup.AnimatorId;
        var component = (Code.Gameplay.Features.Animations.AnimatorId)CreateComponent(index, typeof(Code.Gameplay.Features.Animations.AnimatorId));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveAnimatorId() {
        RemoveComponent(GameComponentsLookup.AnimatorId);
        return this;
    }
}
