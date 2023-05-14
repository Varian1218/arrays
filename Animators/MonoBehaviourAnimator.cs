using System;
using UnityEngine;

namespace Animators
{
    public class MonoBehaviourAnimator : Animator, IAnimator
    {
        private readonly IAnimator _impl;

        public MonoBehaviourAnimator()
        {
            _impl = this.ToDelegateAnimator();
        }

        public event Action<string> Message
        {
            add => _impl.Message += value;
            remove => _impl.Message -= value;
        }

        public bool Exits(string hash)
        {
            return _impl.Exits(hash);
        }
    }
}