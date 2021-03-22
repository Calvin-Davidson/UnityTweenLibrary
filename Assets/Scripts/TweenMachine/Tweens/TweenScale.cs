using System;
using TweenMachine.Tweens;
using UnityEngine;

namespace TweenMachine.Tweens
{
    public class TweenScale : Tween
    {
        protected readonly Vector3 StartScale;
        protected readonly Vector3 TargetScale;
        
        
        public TweenScale(GameObject gameObject, Vector3 targetScale, float speed, Func<float, float> tweenMethode) : base(gameObject, speed, tweenMethode)
        {
            StartScale = gameObject.transform.localScale;
            TargetScale = targetScale;
        }

        public override void UpdateTween(float deltaTime)
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

                _gameObject.transform.localScale = Vector3.LerpUnclamped(StartScale, TargetScale, easingstep);
                return;
            }

            _gameObject.transform.localScale = TargetScale;
            IsFinished = true;
            OnComplete?.Invoke();
        }
    }
}