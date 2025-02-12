using Code.Gameplay.Features.Animations;

namespace Code.Gameplay.Features.Fighter.Behaviours
{
  public interface IAnimationStateReader
  {
    void EnteredState(int stateHash, float length);
    void ExitedState(int stateHash);
    AnimationTypeId AnimationTypeId { get; }
  }
}