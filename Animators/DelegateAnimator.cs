using System;

namespace Animators
{
    public class DelegateAnimator : IAnimator
    {
        public event Action<string> Message;
        public Action<string> Play { private get; set; }

        public bool Exits(string hash)
        {
            throw new NotImplementedException();
        }

        void IAnimator.Play(string hash)
        {
            Play(hash);
        }

        public void OnMessage(string message)
        {
            Message.Invoke(message);
        }
    }
}