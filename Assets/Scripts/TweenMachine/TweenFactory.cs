using System;
using TweenMachine.Tweens;
using UnityEngine;
using Object = System.Object;

namespace TweenMachine
{
    struct TweenData
    {
        public Object Value;
        public float Speed;
        public EasingType Type;
        public bool IsActive;
    }

    public class TweenFactory
    {
        private int _finishedTweens = 0;


        private TweenData _scaleData;
        private TweenData _rotationData;
        private TweenData _positionData;
        private TweenData _colorData;

        public Action OnTweenComplete;

        public Action ScaleTweenComplete;
        public Action PositionTweenComplete;
        public Action RotationTweenComplete;
        public Action ColorTweenComplete;

        private GameObject _gameObject;


        // Every tween needs a object to tween
        public TweenFactory(GameObject gameObject)
        {
            _gameObject = gameObject;
        }


        public TweenFactory TweenScale(Vector3 targetScale, float speed, EasingType easingType)
        {
            _scaleData = new TweenData {Speed = speed, Type = easingType, Value = targetScale, IsActive = true};
            return this;
        }

        public TweenFactory TweenRotation(Vector3 targetRotation, float speed, EasingType easingType)
        {
            _rotationData = new TweenData {Speed = speed, Type = easingType, Value = targetRotation, IsActive = true};
            return this;
        }

        public TweenFactory TweenPosition(Vector3 targetPosition, float speed, EasingType easingType)
        {
            _positionData = new TweenData {Speed = speed, Type = easingType, Value = targetPosition, IsActive = true};
            return this;
        }

        public TweenFactory TweenColor(Color color, float speed, EasingType easingType)
        {
            _colorData = new TweenData {Speed = speed, Type = easingType, Value = color, IsActive = true};
            return this;
        }

        public bool StartTween()
        {
            if (!_positionData.IsActive && !_colorData.IsActive && !_scaleData.IsActive && !_rotationData.IsActive)
            {
                Debug.unityLogger.Log(LogType.Warning, "TweenFactory doesn't tween anything...");
                return false;
            }

            if (_positionData.IsActive)
            {
                Tween tween = new TweenPosition(_gameObject, (Vector3) _positionData.Value, _positionData.Speed,
                    TweenMatcher.Matcher[_positionData.Type]);

                CompleteTween(tween, PositionTweenComplete);
            }

            if (_scaleData.IsActive)
            {
                Tween tween = new TweenScale(_gameObject, (Vector3) _scaleData.Value, _scaleData.Speed,
                    TweenMatcher.Matcher[_scaleData.Type]);

                CompleteTween(tween, ScaleTweenComplete);
            }

            if (_rotationData.IsActive)
            {
                Tween tween = new TweenRotation(_gameObject, (Vector3) _rotationData.Value, _rotationData.Speed,
                    TweenMatcher.Matcher[_rotationData.Type]);

                CompleteTween(tween, RotationTweenComplete);
            }

            if (_colorData.IsActive)
            {
                Tween tween = new TweenColor(_gameObject, (Color) _colorData.Value, _colorData.Speed,
                    TweenMatcher.Matcher[_colorData.Type]);

                CompleteTween(tween, ColorTweenComplete);
            }

            return true;
        }


        private void CompleteTween(Tween tween, Action onCompleteAction)
        {
            tween.OnComplete = () =>
            {
                onCompleteAction?.Invoke();
                _finishedTweens += 1;
                CheckComplete();
            };

            TweenController.Instance.ActiveTweens.Add(tween);
        }

        private void CheckComplete()
        {
            int tweenAmount = 0;
            if (_rotationData.IsActive || _scaleData.IsActive || _positionData.IsActive || _colorData.IsActive) tweenAmount += 1;
            if (tweenAmount != _finishedTweens) return;

            OnTweenComplete?.Invoke();
        }
    }
}