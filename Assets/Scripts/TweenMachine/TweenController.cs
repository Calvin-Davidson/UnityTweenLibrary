using System;
using System.Collections.Generic;
using UnityEngine;

namespace TweenMachine
{
    class TweenController : MonoBehaviour
    {
        private static TweenController _instance;

        private readonly Dictionary<TweenType, List<Tween>> _activeTweens = new Dictionary<TweenType, List<Tween>>
        {
            {
                TweenType.Position,
                new List<Tween>()
            },
            {
                TweenType.Rotation,
                new List<Tween>()
            },
            {
                TweenType.Scale,
                new List<Tween>()
            },
        };


        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Debug.LogError("Er mag maar 1 TweenMachine bestaan!");
            }
        }


        private void Update()
        {
            if (_activeTweens.Count < 1) return;

            foreach (var keyValuePair in _activeTweens)
            {
                for (int i = 0; i < _activeTweens[keyValuePair.Key].Count; i++)
                {
                    Tween tween = _activeTweens[keyValuePair.Key][i];
                    switch (keyValuePair.Key)
                    {
                        case TweenType.Position:
                            tween.UpdatePosition(Time.deltaTime);
                            break;
                        case TweenType.Rotation:
                            tween.UpdateRotation(Time.deltaTime);
                            break;
                        case TweenType.Scale:
                            tween.UpdateScale(Time.deltaTime);
                            break;
                    }

                    if (!tween.IsFinished) continue;
                    _activeTweens[keyValuePair.Key].RemoveAt(i);
                    i -= 1;
                }
            }
        }

        public void MoveGameObject(GameObject objectToMove, Vector3 targetPosition, float speed, EasingType easeType)
        {
            Tween newTween = new Tween(objectToMove, targetPosition, speed, objectToMove.transform.position, TweenMatcher.Matcher[easeType]);
            _activeTweens[TweenType.Position].Add(newTween);
        }


        public Dictionary<TweenType, List<Tween>> ActiveTweens => _activeTweens;

        public static TweenController Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject gameObject = new GameObject();
                    gameObject.AddComponent<TweenController>();
                    _instance = gameObject.GetComponent<TweenController>();
                }

                return _instance;
            }
        }
    }
}