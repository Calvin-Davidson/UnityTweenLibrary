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
        protected override void OnTweenComplete()
        {
            Material.color = TargetColor;
        }

        protected override void OnTweenUpdate(float easeStep)
        {
            Material.color = Color.LerpUnclamped(StartColor, TargetColor, easeStep);
        }
    }
}