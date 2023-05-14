using Tasks;
using UnityEngine;

namespace Animators.TaskAnimators
{
    public class MonoBehaviourTaskAnimator : Animator, ITaskAnimator
    {
        private readonly ITaskAnimator _impl;
        public IAnimator Animator => _impl.Animator;

        public MonoBehaviourTaskAnimator()
        {
            _impl = new TaskAnimator
            {
                Animator = this.ToDelegateAnimator(),
                Capacity = 8
            };
        }

        public ITask WaitMessage(string message)
        {
            return _impl.WaitMessage(message);
        }
    }
}