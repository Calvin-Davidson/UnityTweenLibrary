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

        public virtual void UpdateTween(float deltaTime)
        {
            {
                if (!_started)
                {
                    _started = true;
                    OnStart?.Invoke();
                }
            
                OnUpdate?.Invoke();
                if (_percent < 1)
                {
                    _percent += deltaTime / _speed;
                    float easingstep = _tweenMethode(_percent);
                    OnTweenUpdate(easingstep);
                    return;
                }

                OnTweenComplete();
                IsFinished = true;
                OnComplete?.Invoke();
            }
        }

        protected abstract void OnTweenComplete();
        protected abstract void OnTweenUpdate(float easeStep);
    }
}