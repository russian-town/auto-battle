//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCurrentHealth;

    public static Entitas.IMatcher<GameEntity> CurrentHealth {
        get {
            if (_matcherCurrentHealth == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentHealth);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentHealth = matcher;
            }

            return _matcherCurrentHealth;
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

    public Code.Gameplay.Features.Lifetime.CurrentHealth currentHealth { get { return (Code.Gameplay.Features.Lifetime.CurrentHealth)GetComponent(GameComponentsLookup.CurrentHealth); } }
    public float CurrentHealth { get { return currentHealth.Value; } }
    public bool hasCurrentHealth { get { return HasComponent(GameComponentsLookup.CurrentHealth); } }

    public GameEntity AddCurrentHealth(float newValue) {
        var index = GameComponentsLookup.CurrentHealth;
        var component = (Code.Gameplay.Features.Lifetime.CurrentHealth)CreateComponent(index, typeof(Code.Gameplay.Features.Lifetime.CurrentHealth));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceCurrentHealth(float newValue) {
        var index = GameComponentsLookup.CurrentHealth;
        var component = (Code.Gameplay.Features.Lifetime.CurrentHealth)CreateComponent(index, typeof(Code.Gameplay.Features.Lifetime.CurrentHealth));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveCurrentHealth() {
        RemoveComponent(GameComponentsLookup.CurrentHealth);
        return this;
    }
}
