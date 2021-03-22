using TweenMachine;
using UnityEngine;

public class TweenTester : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed;
    public EasingType easingType;

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        //     TweenController.Instance.MoveGameObject(gameObject, targetPosition, speed, easingType);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TweenFactory factory = new TweenFactory(this.gameObject);

            factory.TweenPosition(targetPosition, speed, easingType);
            factory.TweenScale(new Vector3(0.5f, 0.5f, 0.5f), speed * 3, EasingType.Linear);
            factory.TweenRotation(new Vector3(45, 45, 0), speed, easingType);

            factory.OnTweenComplete = () => { print("TWEEN FINISHED"); };

            factory.RotationTweenComplete = () => { print("rotation finished"); };
            factory.StartTween();
        }
    }
}