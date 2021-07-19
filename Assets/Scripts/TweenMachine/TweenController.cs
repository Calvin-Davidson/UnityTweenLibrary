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
        public bool pauseAllTweens = false;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Debug.LogError("Er mag maar 1 TweenMachine bestaan!");
        }


        private void Update()
        {
            if (pauseAllTweens) return;
            if (_activeTweens.Count < 1) Destroy(this.gameObject);

            for (int i = _activeTweens.Count - 1; i >= 0; i--)
            {
                Tween tween = _activeTweens[i];
                tween.UpdateTween(Time.deltaTime);
                if (!tween.IsFinished) continue;

                _activeTweens.RemoveAt(i);
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
                    _instance = gameObject.AddComponent<TweenController>();
                }

                return _instance;
            }
        }
    }
}