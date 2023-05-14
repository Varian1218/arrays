using Tasks;

namespace Animators.TaskAnimators
{
    public static class TaskAnimatorUtility
    {
        public static async ITask<bool> WaitMessagePlay(
            this TaskAnimator animator,
            string animation,
            string message
        )
        {
            if (string.IsNullOrEmpty(message))
            {
                animator.Animator.Play(message);
                await animator.WaitMessage(message);
                return true;
            }

            return false;
        }
    }
}