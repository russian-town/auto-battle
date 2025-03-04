//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMana;

    public static Entitas.IMatcher<GameEntity> Mana {
        get {
            if (_matcherMana == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Mana);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMana = matcher;
            }

            return _matcherMana;
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

    public Code.Gameplay.Features.Fighter.Mana mana { get { return (Code.Gameplay.Features.Fighter.Mana)GetComponent(GameComponentsLookup.Mana); } }
    public int Mana { get { return mana.Value; } }
    public bool hasMana { get { return HasComponent(GameComponentsLookup.Mana); } }

    public GameEntity AddMana(int newValue) {
        var index = GameComponentsLookup.Mana;
        var component = (Code.Gameplay.Features.Fighter.Mana)CreateComponent(index, typeof(Code.Gameplay.Features.Fighter.Mana));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceMana(int newValue) {
        var index = GameComponentsLookup.Mana;
        var component = (Code.Gameplay.Features.Fighter.Mana)CreateComponent(index, typeof(Code.Gameplay.Features.Fighter.Mana));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveMana() {
        RemoveComponent(GameComponentsLookup.Mana);
        return this;
    }
}
