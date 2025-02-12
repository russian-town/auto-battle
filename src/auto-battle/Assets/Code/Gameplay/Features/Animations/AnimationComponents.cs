using Entitas;

namespace Code.Gameplay.Features.Animations
{
    [Game] public class AnimationHash : IComponent { public int Value; }
    [Game] public class CurrentTime : IComponent { public float Value; }
    [Game] public class Length : IComponent { public float Value; }
    [Game] public class AnimationEnded : IComponent { }
}
