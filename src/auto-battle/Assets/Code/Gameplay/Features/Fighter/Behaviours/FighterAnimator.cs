using System.Linq;
using Code.Common.Extensions;
using UnityEngine;

namespace Code.Gameplay.Features.Fighter.Behaviours
{
    public class FighterAnimator : MonoBehaviour
    {
        private readonly int _defaultAttackToHash = Animator.StringToHash("DefaultAttack");
        private readonly int _doubleStrikeToHash = Animator.StringToHash("DoubleStrike");
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

        public float PlayDefaultAttack()
        {
            Animator.SetTrigger(_defaultAttackToHash);
            var clipInfo = Animator.GetCurrentAnimatorClipInfo(0);
            return clipInfo[0].clip.length;
        }

        public void PlayDoubleStrike() => Animator.SetTrigger(_doubleStrikeToHash);

        public float PlayHit()
        {
            Animator.SetTrigger(_hitToHash);
            var clipInfo = Animator.GetCurrentAnimatorClipInfo(0);
            return clipInfo[0].clip.length;
        }
        
        public float PlayBlock()
        {
            Animator.SetTrigger(_blockToHash);
            var clipInfo = Animator.GetCurrentAnimatorClipInfo(0);
            return clipInfo[0].clip.length;
        }

        public float PlayDodge()
        {
            Animator.SetTrigger(_dodgeToHash);
            var clipInfo = Animator.GetCurrentAnimatorClipInfo(0);
            var length = clipInfo[0].clip.length;
            return length;
        }

        public float PlayCounterattack()
        {
            Animator.SetTrigger(_counterattackToHash);
            var clipInfo = Animator.GetCurrentAnimatorClipInfo(0);
            return clipInfo[0].clip.length;
        }

        public void PlayFall() => Animator.SetTrigger(_fallToHash);
        public void PlayStandUp() => Animator.SetTrigger(_standUpToHash);
        public void PlayMoveForward() => Animator.SetBool(_moveForwardToHash, true);
        public void PlayMoveBackward() => Animator.SetBool(_moveBackwardToHash, true);
    }
}
