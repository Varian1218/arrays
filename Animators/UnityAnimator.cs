using System;
using UnityEngine;

namespace Animators
{
    public class UnityAnimator : IAnimator
    {
        private Animator _impl;
        public event Action<string> Message;

        public Animator Impl
        {
            set => _impl = value;
        }

        public void Play(string hash)
        {
            _impl.Play(hash);
        }

        public void Play(int hashCode)
        {
            _impl.Play(hashCode);
        }

        public void OnMessage(string message)
        {
            Message.Invoke(message);
        }
    }
}