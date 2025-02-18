using Code.Gameplay.Features.Animations;

namespace Code.Gameplay.Features.Fighter.Behaviours
{
  public interface IAnimationStateReader
  {
    void EnteredState(float length, int layer);
    void ExitedState(int stateHash);
    AnimationTypeId AnimationTypeId { get; }
  }
}