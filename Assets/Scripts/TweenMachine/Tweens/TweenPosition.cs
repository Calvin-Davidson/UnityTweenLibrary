using System;
using TweenMachine.Tweens;
using UnityEngine;

namespace TweenMachine.Tweens
{
    class TweenPosition : Tween
    {
        protected readonly Vector3 Direction;
        protected readonly Vector3 StartPosition;
        protected readonly Vector3 TargetPosition;

        public TweenPosition(GameObject gameObject, Vector3 targetPosition, float speed, Func<float, float> tweenMethode) : base(gameObject, speed, tweenMethode)
        {
            StartPosition = gameObject.transform.position;
            TargetPosition = targetPosition;
            
            Direction = TargetPosition - StartPosition;
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
                _gameObject.transform.position = StartPosition + (Direction * easingstep);
                return;
            }

            _gameObject.transform.position = TargetPosition;
            IsFinished = true;
            OnComplete?.Invoke();
        }
    }
}