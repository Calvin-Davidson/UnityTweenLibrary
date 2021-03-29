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

        protected override void OnTweenComplete()
        {
            _gameObject.transform.localScale = TargetScale;
        }

        protected override void OnTweenUpdate(float easeStep)
        {
            _gameObject.transform.localScale = Vector3.LerpUnclamped(StartScale, TargetScale, easeStep);
        }
    }
}