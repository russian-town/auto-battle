//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int Destructed = 0;
    public const int SelfDestructTimer = 1;
    public const int View = 2;
    public const int ViewPath = 3;
    public const int ViewPrefab = 4;
    public const int Id = 5;
    public const int Transform = 6;
    public const int WorldPosition = 7;
    public const int WorldRotation = 8;
    public const int Hero = 9;
    public const int CurrentHealth = 10;
    public const int Dead = 11;
    public const int MaxHealth = 12;
    public const int ProcessingDeath = 13;
    public const int Direction = 14;
    public const int Moving = 15;
    public const int Speed = 16;
    public const int AxisInput = 17;
    public const int Input = 18;

    public const int TotalComponents = 19;

    public static readonly string[] componentNames = {
        "Destructed",
        "SelfDestructTimer",
        "View",
        "ViewPath",
        "ViewPrefab",
        "Id",
        "Transform",
        "WorldPosition",
        "WorldRotation",
        "Hero",
        "CurrentHealth",
        "Dead",
        "MaxHealth",
        "ProcessingDeath",
        "Direction",
        "Moving",
        "Speed",
        "AxisInput",
        "Input"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Code.Common.Destructed),
        typeof(Code.Common.SelfDestructTimer),
        typeof(Code.Common.View),
        typeof(Code.Common.ViewPath),
        typeof(Code.Common.ViewPrefab),
        typeof(Code.Gameplay.Common.CommonComponents.Id),
        typeof(Code.Gameplay.Common.CommonComponents.TransformComponent),
        typeof(Code.Gameplay.Common.CommonComponents.WorldPosition),
        typeof(Code.Gameplay.Common.CommonComponents.WorldRotation),
        typeof(Code.Gameplay.Features.Hero.Hero),
        typeof(Code.Gameplay.Features.Lifetime.CurrentHealth),
        typeof(Code.Gameplay.Features.Lifetime.Dead),
        typeof(Code.Gameplay.Features.Lifetime.MaxHealth),
        typeof(Code.Gameplay.Features.Lifetime.ProcessingDeath),
        typeof(Code.Gameplay.Features.Movement.Direction),
        typeof(Code.Gameplay.Features.Movement.Moving),
        typeof(Code.Gameplay.Features.Movement.Speed),
        typeof(Code.Gameplay.Input.AxisInput),
        typeof(Code.Gameplay.Input.Input)
    };
}
