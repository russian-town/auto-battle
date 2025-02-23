//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherBlockAbility;

    public static Entitas.IMatcher<GameEntity> BlockAbility {
        get {
            if (_matcherBlockAbility == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BlockAbility);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBlockAbility = matcher;
            }

            return _matcherBlockAbility;
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

    static readonly Code.Gameplay.Features.Abilities.BlockAbility blockAbilityComponent = new Code.Gameplay.Features.Abilities.BlockAbility();

    public bool isBlockAbility {
        get { return HasComponent(GameComponentsLookup.BlockAbility); }
        set {
            if (value != isBlockAbility) {
                var index = GameComponentsLookup.BlockAbility;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : blockAbilityComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
