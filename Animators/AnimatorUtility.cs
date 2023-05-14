using UnityEngine;

namespace Animators
{
    public static class AnimatorUtility
    {
        public static DelegateAnimator ToDelegateAnimator(this Animator animator)
        {
            return new DelegateAnimator
            {
                Play = animator.Play
            };
        }
    }
}