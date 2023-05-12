using System.Collections.Generic;
using Tasks;

namespace Animators.TaskAnimators
{
    public class TaskAnimator : ITaskAnimator
    {
        private IAnimator _animator;
        private readonly Awaiter _awaiter = new();
        private string _message;
        private HashSet<string> _messages;

        public IAnimator Animator
        {
            get => _animator;
            set
            {
                _animator = value;
                value.Message += OnMessage;
            }
        }

        public int Capacity
        {
            set => _messages = new HashSet<string>(value);
        }

        public void Destroy()
        {
            _animator.Message -= OnMessage;
        }

        private void OnMessage(string message)
        {
            if (_message == message)
            {
                _awaiter.Complete();
            }

            _messages.Add(message);
        }

        public ITask WaitMessage(string message)
        {
            if (_messages.Remove(message))
            {
                return TaskUtils.CompletedTask;   
            }

            _awaiter.Clear();
            return new AwaiterTask(_awaiter);
        }
    }
}