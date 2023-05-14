using System;

namespace Animators
{
    public interface IAnimator
    {
        event Action<string> Message;
        bool Exits(string hash);
        void Play(string hash);
    }
}