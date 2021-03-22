using System;
using UnityEngine;

namespace TweenMachine.Tweens
{
    public abstract class Tween
    {
        protected readonly GameObject _gameObject;
        protected readonly float _speed;
        protected readonly Func<float, float> _tweenMethode;
        protected bool _started = false;

        public Action OnComplete;
        public Action OnUpdate;
        public Action OnStart;

        protected float _percent;

        protected Tween(GameObject gameObject, float speed, Func<float, float> tweenMethode)
        {
            _gameObject = gameObject;
            _speed = speed;
            _percent = 0;
            _tweenMethode = tweenMethode;    
        }
        
        public bool IsFinished { get; protected set; }
        public abstract void UpdateTween(float deltaTime);
    }
}