using System;
using UnityEngine;

namespace Animators
{
    public class MonoBehaviourAnimator : Animator, IAnimator
    {
        public event Action<string> Message;

        public void OnMessage(string message)
        {
            Message?.Invoke(message);
        }
    }
}