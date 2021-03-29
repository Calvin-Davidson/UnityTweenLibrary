using System;
using System.Collections.Generic;

namespace TweenMachine
{
    class TweenMatcher
    {
        // self filling hashmap with all tween types and methodes.
        public static readonly Dictionary<EasingType, Func<float, float>> Matcher = new Dictionary<EasingType, Func<float, float>>
        {
            {
                EasingType.Linear, TweenMethode.Linear
            },
            {
                EasingType.EaseInSine, TweenMethode.EaseInSine
            },
            {
                EasingType.EaseOutSine, TweenMethode.EaseOutSine
            },
            {
                EasingType.EaseInOutSine, TweenMethode.EaseInOutSine
            },
            
            {
                EasingType.EaseInCubic, TweenMethode.EaseInCubic
            },
            {
                EasingType.EaseOutCubic, TweenMethode.EaseOutCubic
            },
            {
                EasingType.EaseInOutCubic, TweenMethode.EaseInOutCubic
            },
            {
                EasingType.EaseInQuint, TweenMethode.EaseInQuint
            },
            {
                EasingType.EaseOutQuint, TweenMethode.EaseOutQuint
            },
            {
                EasingType.EaseInOutQuint, TweenMethode.EaseInOutQuint
            },
            {
                EasingType.EaseInCirc, TweenMethode.EaseInCirc
            },
            {
                EasingType.EaseOutCirc, TweenMethode.EaseOutCirc
            },
            {
                EasingType.EaseInOutCirc, TweenMethode.EaseInOutCirc
            },
            {
                EasingType.EaseInElastic, TweenMethode.EaseInElastic
            },
            {
                EasingType.EaseOutElastic, TweenMethode.EaseOutElastic
            },
            {
                EasingType.EaseInOutElastic, TweenMethode.EaseOutElastic
            },
            {
                EasingType.EaseInQuad, TweenMethode.EaseInQuad
            },
            {
                EasingType.EaseOutQuad, TweenMethode.EaseOutQuad
            },
            {
                EasingType.EaseInOutQuad, TweenMethode.EaseInOutQuad
            },
            {
                EasingType.EaseInQuart, TweenMethode.EaseInQuart
            },
            {
                EasingType.EaseOutQuart, TweenMethode.EaseOutQuart
            },
            {
                EasingType.EaseInOutQuart, TweenMethode.EaseInOutQuart
            },
            {
                EasingType.EaseInExpo, TweenMethode.EaseInExpo
            },
            {
                EasingType.EaseOutExpo, TweenMethode.EaseOutExpo
            },
            {
                EasingType.EaseInOutExpo, TweenMethode.EaseInOutExpo
            },
            {
                EasingType.EaseInBack, TweenMethode.EaseInBack
            },
            {
                EasingType.EaseOutBack, TweenMethode.EaseOutBack
            },
            {
                EasingType.EaseInOutBack, TweenMethode.EaseInOutBack
            },
            {
                EasingType.EaseInBounce, TweenMethode.EaseInBounce
            },
            {
                EasingType.EaseOutBounce, TweenMethode.EaseOutBounce
            },
            {
                EasingType.EaseInOutBounce, TweenMethode.EaseInOutBounce
            },
        };
    }
}