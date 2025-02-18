namespace Code.Gameplay.Features.Animations.Factory
{
    public interface IAnimationFactory
    {
        public GameEntity CreateAnimation(int hashCode, float length);
    }
}
