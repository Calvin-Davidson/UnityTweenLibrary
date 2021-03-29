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
        

        protected override void OnTweenComplete()
        {
            _gameObject.transform.rotation = Quaternion.Euler(TargetRotation);
        }

        protected override void OnTweenUpdate(float easeStep)
        {
            _gameObject.transform.rotation = Quaternion.Euler(StartRotation + (Direction * easeStep));
        }
    }
}