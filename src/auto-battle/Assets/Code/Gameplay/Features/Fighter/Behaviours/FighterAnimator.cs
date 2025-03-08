using UnityEngine;

namespace Code.Gameplay.Features.Fighter.Behaviours
{
    public class FighterAnimator : MonoBehaviour
    {
        public Animator Animator;

        public void Play(int hashCode, float normalizedTime) =>
            Animator.Play(hashCode, GetLayerIndex(hashCode), normalizedTime);

        public void InterruptAnimation() => Animator.StopPlayback();

        public float GetCurrentFrame(int hashCode, float normalizeTime)
        {
            var layerIndex = GetLayerIndex(hashCode);
            var clips = Animator.GetCurrentAnimatorClipInfo(layerIndex);

            if (clips.Length == 0)
                return 0f;

            var clip = clips[0].clip;
            var state = Animator.GetCurrentAnimatorStateInfo(layerIndex);

            if (state.shortNameHash != hashCode)
                return 0f;

            var frame = clip.length * clip.frameRate;
            return frame * Mathf.Clamp01(normalizeTime);
        }

        private int GetLayerIndex(int hashCode)
        {
            for (var i = 0; i < Animator.layerCount; i++)
            {
                var stateInfo = Animator.GetCurrentAnimatorStateInfo(i);

                if (stateInfo.shortNameHash == hashCode)
                    return i;
            }

            return 0;
        }
    }
}
