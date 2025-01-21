//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherVitamins;

    public static Entitas.IMatcher<GameEntity> Vitamins {
        get {
            if (_matcherVitamins == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Vitamins);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVitamins = matcher;
            }

            return _matcherVitamins;
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

    static readonly Code.Gameplay.Features.Buffs.VitaminsComponent vitaminsComponent = new Code.Gameplay.Features.Buffs.VitaminsComponent();

    public bool isVitamins {
        get { return HasComponent(GameComponentsLookup.Vitamins); }
        set {
            if (value != isVitamins) {
                var index = GameComponentsLookup.Vitamins;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : vitaminsComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}