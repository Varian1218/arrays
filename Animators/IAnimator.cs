using System;

namespace Animators
{
    public interface IAnimator
    {
        event Action<string> Message; 
        void Play(string hash);
        void Play(int hashCode);
    }
}