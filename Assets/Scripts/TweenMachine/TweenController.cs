using System;
using System.Collections.Generic;
using TweenMachine.Tweens;
using UnityEngine;

namespace TweenMachine
{
    class TweenController : MonoBehaviour
    {
        private static TweenController _instance;

        private readonly List<Tween> _activeTweens = new List<Tween>();


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

            for (int i = 0; i < _activeTweens.Count; i++)
            {
                Tween tween = _activeTweens[i];
                tween.UpdateTween(Time.deltaTime);
                if (!tween.IsFinished) continue;

                _activeTweens.RemoveAt(i);
                i -= 1;
            }
        }

        public List<Tween> ActiveTweens => _activeTweens;

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