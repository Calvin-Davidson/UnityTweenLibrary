using System;
using TweenMachine.Tweens;
using UnityEngine;

namespace TweenMachine
{
    struct TweenData
    {
        public Vector3 Value;
        public float Speed;
        public EasingType Type;
    }

    public class TweenFactory
    {
        private bool _scale = false;
        private bool _rotation = false;
        private bool _position = false;
        private bool _color;

        private bool _scaleIsFinished = false;
        private bool _rotationIsFinished = false;
        private bool _positionIsFinished = false;
        private bool _colorIsFinished = false;


        private TweenData _scaleData;
        private TweenData _rotationData;
        private TweenData _positionData;

        private TweenData _colorData;
        private Color colorData;

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
            _scale = true;
            _scaleData = new TweenData {Speed = speed, Type = easingType, Value = targetScale};
            return this;
        }

        public TweenFactory TweenRotation(Vector3 targetRotation, float speed, EasingType easingType)
        {
            _rotation = true;
            _rotationData = new TweenData {Speed = speed, Type = easingType, Value = targetRotation};
            return this;
        }

        public TweenFactory TweenPosition(Vector3 targetPosition, float speed, EasingType easingType)
        {
            _position = true;
            _positionData = new TweenData {Speed = speed, Type = easingType, Value = targetPosition};
            return this;
        }

        public TweenFactory TweenColor(Color color, float speed, EasingType easingType)
        {
            _color = true;
            _colorData = new TweenData {Speed = speed, Type = easingType};
            colorData = color;
            return this;
        }

        public bool StartTween()
        {
            if (_position == false && _rotation == false && _scale == false)
            {
                Debug.unityLogger.Log(LogType.Warning, "TweenFactory doesn't tween anything...");
                return false;
            }

            if (_position)
            {
                Tween tween = new TweenPosition(_gameObject, _positionData.Value, _positionData.Speed,
                    TweenMatcher.Matcher[_positionData.Type]);

                tween.OnComplete = () =>
                {
                    PositionTweenComplete?.Invoke();
                    _positionIsFinished = true;
                    CheckComplete();
                };

                TweenController.Instance.ActiveTweens.Add(tween);
            }

            if (_scale)
            {
                Tween tween = new TweenScale(_gameObject, _scaleData.Value, _scaleData.Speed,
                    TweenMatcher.Matcher[_scaleData.Type]);

                tween.OnComplete = () =>
                {
                    ScaleTweenComplete?.Invoke();
                    _scaleIsFinished = true;
                    CheckComplete();
                };

                TweenController.Instance.ActiveTweens.Add(tween);
            }

            if (_rotation)
            {
                Tween tween = new TweenRotation(_gameObject, _rotationData.Value, _rotationData.Speed,
                    TweenMatcher.Matcher[_rotationData.Type]);

                tween.OnComplete = () =>
                {
                    RotationTweenComplete?.Invoke();
                    _rotationIsFinished = true;
                    CheckComplete();
                };

                TweenController.Instance.ActiveTweens.Add(tween);
            }

            if (_color)
            {
                Tween tween = new TweenColor(_gameObject, colorData, _colorData.Speed,
                    TweenMatcher.Matcher[_colorData.Type]);

                tween.OnComplete = () =>
                {
                    ColorTweenComplete?.Invoke();
                    _colorIsFinished = true;
                    CheckComplete();
                };

                TweenController.Instance.ActiveTweens.Add(tween);
            }

            return true;
        }


        private void CheckComplete()
        {
            if (_rotation && !_rotationIsFinished)
                return;
            if (_scale && !_scaleIsFinished)
                return;
            if (_position && !_positionIsFinished)
                return;
            if (_color && !_colorIsFinished)
                return;

            OnTweenComplete?.Invoke();
        }
    }
}