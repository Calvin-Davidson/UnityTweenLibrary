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

        protected override void OnTweenComplete()
        {
            _gameObject.transform.position = TargetPosition;
        }

        protected override void OnTweenUpdate(float easeStep)
        {
            _gameObject.transform.position = StartPosition + (Direction * easeStep);
        }
    }
}