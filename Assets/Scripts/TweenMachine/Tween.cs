using System;
using UnityEngine;

namespace TweenMachine
{
    class Tween
    {
        private readonly GameObject _gameObject;
        private readonly Vector3 _startPosition;
        private readonly Vector3 _targetPosition;
        private readonly Vector3 _direction;
        private readonly float _speed;
        private readonly Func<float, float> _tweenMethode;
        private bool _started = false;
        
        public Action OnComplete;
        public Action OnUpdate;
        public Action onStart;

        private float _percent;
    
        public Tween(GameObject objectToMove, Vector3 targetPosition, float speed, Vector3 startPosition, Func<float, float> tweenMethode)
        {
            _gameObject = objectToMove;
            _targetPosition = targetPosition;
            _speed = speed;

            _startPosition = startPosition;
            _direction = _targetPosition - _startPosition;
            _percent = 0;
            _tweenMethode = tweenMethode;
        }
        public void UpdatePosition(float dt)
        {
            if (!_started)
            {
                _started = true;
                onStart?.Invoke();
            }
            
            OnUpdate?.Invoke();
            if (_percent < 1)
            {
                _percent += dt / _speed;
                float easingstep = _tweenMethode(_percent);
                _gameObject.transform.position = _startPosition + (_direction * easingstep);
                return;
            }

            _gameObject.transform.position = _targetPosition;
            IsFinished = true;
            OnComplete?.Invoke();
        }
        
        public void UpdateRotation(float dt)
        {
            if (!_started)
            {
                _started = true;
                onStart?.Invoke();
            }
            
            OnUpdate?.Invoke();
            if (_percent < 1)
            {
                _percent += dt / _speed;
                float easingstep = _tweenMethode(_percent);
                _gameObject.transform.rotation = Quaternion.Euler(_startPosition + (_direction * easingstep));
                return;
            }

            _gameObject.transform.rotation = Quaternion.Euler(_targetPosition);
            IsFinished = true;
            OnComplete?.Invoke();
        }

        public void UpdateScale(float dt)
        {
            if (!_started)
            {
                _started = true;
                onStart?.Invoke();
            }
            
            OnUpdate?.Invoke();
            if (_percent < 1)
            {
                _percent += dt / _speed;
                float easingstep = _tweenMethode(_percent);

                _gameObject.transform.localScale = Vector3.LerpUnclamped(_startPosition, _targetPosition, easingstep);
                return;
            }

            _gameObject.transform.localScale = _targetPosition;
            IsFinished = true;
            OnComplete?.Invoke();
        }
        
        public bool IsFinished { get; private set; }
    }
}