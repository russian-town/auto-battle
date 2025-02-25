//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ContextsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts : Entitas.IContexts {

    public static Contexts sharedInstance {
        get {
            if (_sharedInstance == null) {
                _sharedInstance = new Contexts();
            }

            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public GameContext game { get; set; }

    public Entitas.IContext[] allContexts { get { return new Entitas.IContext [] { game }; } }

    public Contexts() {
        game = new GameContext();

        var postConstructors = System.Linq.Enumerable.Where(
            GetType().GetMethods(),
            method => System.Attribute.IsDefined(method, typeof(Entitas.CodeGeneration.Attributes.PostConstructorAttribute))
        );

        foreach (var postConstructor in postConstructors) {
            postConstructor.Invoke(this, null);
        }
    }

    public void Reset() {
        var contexts = allContexts;
        for (int i = 0; i < contexts.Length; i++) {
            contexts[i].Reset();
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EntityIndexGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

    public const string AnimationHash = "AnimationHash";
    public const string ApplierStatusLink = "ApplierStatusLink";
    public const string Id = "Id";

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeEntityIndices() {
        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, int>(
            AnimationHash,
            game.GetGroup(GameMatcher.AnimationHash),
            (e, c) => ((Code.Gameplay.Features.Animations.AnimationHash)c).Value));

        game.AddEntityIndex(new Entitas.EntityIndex<GameEntity, int>(
            ApplierStatusLink,
            game.GetGroup(GameMatcher.ApplierStatusLink),
            (e, c) => ((Code.Gameplay.Features.Statuses.ApplierStatusLink)c).Value));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, int>(
            Id,
            game.GetGroup(GameMatcher.Id),
            (e, c) => ((Code.Gameplay.Common.CommonComponents.Id)c).Value));
    }
}

public static class ContextsExtensions {

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithAnimationHash(this GameContext context, int Value) {
        return ((Entitas.EntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.AnimationHash)).GetEntities(Value);
    }

    public static System.Collections.Generic.HashSet<GameEntity> GetEntitiesWithApplierStatusLink(this GameContext context, int Value) {
        return ((Entitas.EntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.ApplierStatusLink)).GetEntities(Value);
    }

    public static GameEntity GetEntityWithId(this GameContext context, int Value) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, int>)context.GetEntityIndex(Contexts.Id)).GetEntity(Value);
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.VisualDebugging.CodeGeneration.Plugins.ContextObserverGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)

    [Entitas.CodeGeneration.Attributes.PostConstructor]
    public void InitializeContextObservers() {
        try {
            CreateContextObserver(game);
        } catch(System.Exception e) {
            UnityEngine.Debug.LogError(e);
        }
    }

    public void CreateContextObserver(Entitas.IContext context) {
        if (UnityEngine.Application.isPlaying) {
            var observer = new Entitas.VisualDebugging.Unity.ContextObserver(context);
            UnityEngine.Object.DontDestroyOnLoad(observer.gameObject);
        }
    }

#endif
}
