using System;
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

        private bool _scaleIsFinished = false;
        private bool _rotationIsFinished = false;
        private bool _positionIsFinished = false;

        private TweenData _scaleData;
        private TweenData _rotationData;
        private TweenData _positionData;

        public Action OnTweenComplete;

        public Action ScaleTweenComplete;
        public Action PositionTweenComplete;
        public Action RotationTweenComplete;

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


        public bool StartTween()
        {
            if (_position == false && _rotation == false && _scale == false)
            {
                Debug.unityLogger.Log(LogType.Warning, "TweenFactory doesn't tween anything...");
                return false;
            }

            if (_position)
            {
                Tween tween = CreateTween(_positionData, _gameObject.transform.position);
                tween.OnComplete = () =>
                {
                    PositionTweenComplete?.Invoke();
                    _positionIsFinished = true;
                    CheckComplete();
                };

                TweenController.Instance.ActiveTweens[TweenType.Position].Add(tween);
            }

            if (_scale)
            {
                Tween tween = CreateTween(_scaleData, _gameObject.transform.localScale);

                tween.OnComplete = () =>
                {
                    ScaleTweenComplete?.Invoke();
                    _scaleIsFinished = true;
                    CheckComplete();
                };

                TweenController.Instance.ActiveTweens[TweenType.Scale].Add(tween);
            }

            if (_rotation)
            {
                Tween tween = CreateTween(_rotationData, _gameObject.transform.rotation.eulerAngles);
                tween.OnComplete = () =>
                {
                    RotationTweenComplete.Invoke();
                    _rotationIsFinished = true;
                    CheckComplete();
                };

                TweenController.Instance.ActiveTweens[TweenType.Rotation].Add(tween);
            }

            return true;
        }


        private Tween CreateTween(TweenData data, Vector3 startPosition)
        {
            return new Tween(_gameObject, data.Value, data.Speed, startPosition, TweenMatcher.Matcher[data.Type]);
        }

        private void CheckComplete()
        {
            if (_rotation && !_rotationIsFinished)
                return;
            if (_scale && !_scaleIsFinished)
                return;
            if (_position && !_positionIsFinished)
                return;

            OnTweenComplete?.Invoke();
        }
    }
}