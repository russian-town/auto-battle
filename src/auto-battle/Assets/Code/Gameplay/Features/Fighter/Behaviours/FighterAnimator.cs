using UnityEngine;

namespace Code.Gameplay.Features.Fighter.Behaviours
{
    public class FighterAnimator : MonoBehaviour
    {
        private readonly int _defaultAttackToHash = Animator.StringToHash("DefaultAttack");
        private readonly int _doublePunchToHash = Animator.StringToHash("DoublePunch");
        private readonly int _hitToHash = Animator.StringToHash("Hit");
        private readonly int _blockToHash = Animator.StringToHash("Block");
        private readonly int _dodgeToHash = Animator.StringToHash("Dodge");
        private readonly int _counterattackToHash = Animator.StringToHash("Counterattack");
        private readonly int _fallToHash = Animator.StringToHash("Fall");
        private readonly int _standUpToHash = Animator.StringToHash("StandUp");
        private readonly int _moveForwardToHash = Animator.StringToHash("MoveForward");
        private readonly int _moveBackwardToHash = Animator.StringToHash("MoveBackward");
        
        private readonly int _rifleShootToHash = Animator.StringToHash("RifleShoot");
        private readonly int _pistolShootToHash = Animator.StringToHash("PistolShoot");
        private readonly int _getKnifeToHash = Animator.StringToHash("GetKnife");
        private readonly int _knifeAttackToHash = Animator.StringToHash("KnifeAttack");
        
        public Animator Animator;

        public void PlayIdle()
        {
            Animator.SetBool(_moveForwardToHash, false);
            Animator.SetBool(_moveBackwardToHash, false);
        }
        
        public void PlayDefaultAttack() => Animator.SetTrigger(_defaultAttackToHash);
        public void PlayDoublePunch() => Animator.SetTrigger(_doublePunchToHash);
        public void PlayHit() => Animator.SetTrigger(_hitToHash);
        public void PlayBlock() => Animator.SetTrigger(_blockToHash);
        public void PlayDodge() => Animator.SetTrigger(_dodgeToHash);
        public void PlayCounterattack() => Animator.SetTrigger(_counterattackToHash);
        public void PlayFall() => Animator.SetTrigger(_fallToHash);
        public void PlayStandUp() => Animator.SetTrigger(_standUpToHash);
        public void PlayMoveForward() => Animator.SetBool(_moveForwardToHash, true);
        public void PlayMoveBackward() => Animator.SetBool(_moveBackwardToHash, true);
    }
}
