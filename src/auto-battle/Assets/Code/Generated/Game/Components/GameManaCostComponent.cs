//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherManaCost;

    public static Entitas.IMatcher<GameEntity> ManaCost {
        get {
            if (_matcherManaCost == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ManaCost);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherManaCost = matcher;
            }

            return _matcherManaCost;
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

    public Code.Gameplay.Features.Abilities.ManaCost manaCost { get { return (Code.Gameplay.Features.Abilities.ManaCost)GetComponent(GameComponentsLookup.ManaCost); } }
    public int ManaCost { get { return manaCost.Value; } }
    public bool hasManaCost { get { return HasComponent(GameComponentsLookup.ManaCost); } }

    public GameEntity AddManaCost(int newValue) {
        var index = GameComponentsLookup.ManaCost;
        var component = (Code.Gameplay.Features.Abilities.ManaCost)CreateComponent(index, typeof(Code.Gameplay.Features.Abilities.ManaCost));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceManaCost(int newValue) {
        var index = GameComponentsLookup.ManaCost;
        var component = (Code.Gameplay.Features.Abilities.ManaCost)CreateComponent(index, typeof(Code.Gameplay.Features.Abilities.ManaCost));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveManaCost() {
        RemoveComponent(GameComponentsLookup.ManaCost);
        return this;
    }
}
