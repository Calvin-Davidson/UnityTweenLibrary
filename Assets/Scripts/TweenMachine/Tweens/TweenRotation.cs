using System;
using UnityEngine;

namespace TweenMachine.Tweens
{
    class TweenRotation : Tween
    {
        protected readonly Vector3 StartRotation;
        protected readonly Vector3 TargetRotation;
        protected readonly Vector3 Direction;
        
        public TweenRotation(GameObject gameObject, Vector3 targetRotation, float speed, Func<float, float> tweenMethode) : base(gameObject, speed, tweenMethode)
        {
            StartRotation = gameObject.transform.rotation.eulerAngles;
            TargetRotation = targetRotation;

            Direction = TargetRotation - StartRotation;
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
                _gameObject.transform.rotation = Quaternion.Euler(StartRotation + (Direction * easingstep));
                return;
            }

            _gameObject.transform.rotation = Quaternion.Euler(TargetRotation);
            IsFinished = true;
            OnComplete?.Invoke();
        }
    }
}