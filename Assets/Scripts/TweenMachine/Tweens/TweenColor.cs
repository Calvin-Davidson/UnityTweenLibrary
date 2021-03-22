using System;
using TweenMachine.Tweens;
using UnityEngine;

namespace TweenMachine.Tweens
{
    public class TweenColor : Tween
    {
        protected readonly Color StartColor;
        protected readonly Color TargetColor;
        protected readonly Material Material;
        
        public TweenColor(GameObject gameObject, Color targetColor, float speed, Func<float, float> tweenMethode) : base(gameObject, speed, tweenMethode)
        {
            Material = gameObject.GetComponent<Renderer>().material;
            StartColor = Material.color;
            TargetColor = targetColor;
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

                Material.color = Color.LerpUnclamped(StartColor, TargetColor, easingstep);
                return;
            }

            Material.color = TargetColor;
            IsFinished = true;
            OnComplete?.Invoke();
        }
    }
}