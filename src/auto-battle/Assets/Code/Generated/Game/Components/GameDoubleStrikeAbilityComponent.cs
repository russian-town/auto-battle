//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDoubleStrikeAbility;

    public static Entitas.IMatcher<GameEntity> DoubleStrikeAbility {
        get {
            if (_matcherDoubleStrikeAbility == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DoubleStrikeAbility);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDoubleStrikeAbility = matcher;
            }

            return _matcherDoubleStrikeAbility;
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

    static readonly Code.Gameplay.Features.Abilities.DoubleStrikeAbility doubleStrikeAbilityComponent = new Code.Gameplay.Features.Abilities.DoubleStrikeAbility();

    public bool isDoubleStrikeAbility {
        get { return HasComponent(GameComponentsLookup.DoubleStrikeAbility); }
        set {
            if (value != isDoubleStrikeAbility) {
                var index = GameComponentsLookup.DoubleStrikeAbility;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : doubleStrikeAbilityComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
