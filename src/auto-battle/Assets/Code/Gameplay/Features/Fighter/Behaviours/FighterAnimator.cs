using Code.Gameplay.Features.Animations;
using Code.Gameplay.Features.Animations.Factory;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Fighter.Behaviours
{
    public class FighterAnimator : MonoBehaviour, IAnimationStateReader
    {
        private readonly int _defaultAttackToHash = Animator.StringToHash("DefaultAttack");
        private readonly int _doubleStrikeToHash = Animator.StringToHash("DoubleStrike");
        private readonly int _hitToHash = Animator.StringToHash("Hit");
        private readonly int _blockToHash = Animator.StringToHash("Block");
        private readonly int _dodgeToHash = Animator.StringToHash("Dodge");
        private readonly int _counterattackToHash = Animator.StringToHash("Counterattack");
        private readonly int _fallToHash = Animator.StringToHash("Fall");
        private readonly int _moveForwardToHash = Animator.StringToHash("MoveForward");
        private readonly int _moveBackwardToHash = Animator.StringToHash("MoveBackward");
        private readonly int _getupToHash = Animator.StringToHash("Getup");
        private readonly int _idleStateHash = Animator.StringToHash("Idle");

        private readonly int _rifleShootToHash = Animator.StringToHash("RifleShoot");
        private readonly int _pistolShootToHash = Animator.StringToHash("PistolShoot");
        private readonly int _getKnifeToHash = Animator.StringToHash("GetKnife");
        private readonly int _knifeAttackToHash = Animator.StringToHash("KnifeAttack");

        private IAnimationFactory _animationFactory;

        public Animator Animator;

        public AnimationTypeId AnimationTypeId { get; private set; }

        [Inject]
        public void Construct(IAnimationFactory animationFactory) =>
            _animationFactory = animationFactory;

        public void PlayIdle()
        {
            Animator.SetBool(_moveForwardToHash, false);
            Animator.SetBool(_moveBackwardToHash, false);
        }

        public void PlayDefaultAttack() => Animator.SetTrigger(_defaultAttackToHash);
        public void PlayDoubleStrike() => Animator.SetTrigger(_doubleStrikeToHash);
        public void PlayHit() => Animator.SetTrigger(_hitToHash);
        public void PlayBlock() => Animator.SetTrigger(_blockToHash);
        public void PlayDodge() => Animator.SetTrigger(_dodgeToHash);
        public void PlayCounterattack() => Animator.SetTrigger(_counterattackToHash);
        public void PlayFall() => Animator.SetTrigger(_fallToHash);
        public void PlayGetup() => Animator.SetTrigger(_getupToHash);
        public void PlayMoveForward() => Animator.SetBool(_moveForwardToHash, true);
        public void PlayMoveBackward() => Animator.SetBool(_moveBackwardToHash, true);
        public void Cleanup() => Animator.ResetTrigger(_defaultAttackToHash);

        public void EnteredState(int stateHash, float length)
        {
            _animationFactory.CreateAnimation(stateHash, length);
        }

        public void ExitedState(int stateHash) { }
    }
}
