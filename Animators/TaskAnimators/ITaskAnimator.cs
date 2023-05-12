using Tasks;

namespace Animators.TaskAnimators
{
    public interface ITaskAnimator
    {
        IAnimator Animator { get; }
        ITask WaitMessage(string message);
    }
}