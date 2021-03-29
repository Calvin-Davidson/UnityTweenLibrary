using System;
using TweenMachine;
using UnityEngine;

public class TweenTester : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed;
    public EasingType easingType;

    public Color color;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TweenFactory factory = new TweenFactory(this.gameObject);

            factory.TweenPosition(targetPosition, 5, EasingType.Linear);
            factory.TweenRotation(new Vector3(45, 45, 0), 5, EasingType.Linear);
            factory.TweenScale(new Vector3(0.5f, 0.5f, 0.5f), 5, EasingType.Linear);
            factory.TweenColor(color, 8, EasingType.Linear);

            factory.OnTweenComplete = () =>
            {
                print("completed");
            };
            
            factory.StartTween();
        }
    }
}