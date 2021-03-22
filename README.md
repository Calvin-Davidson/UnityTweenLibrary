![alt text](https://img.shields.io/static/v1?label=Unity&message=TweenLibrary&color=red)
# Unity Tween Library

## Installation

Download the project and add the folder > Assets > Scripts > TweenMachine   
to your project. after that you can start using the TweenMachine library

## Usage

### Tweening Scale
```cs
TweenFactory factory = new TweenFactory(this.gameObject);

factory.TweenScale(new Vector3(0.5f, 0.5f, 0.5f), 5, EasingType.Linear);

factory.StartTween();
```

### Tweening Rotation
```cs
TweenFactory factory = new TweenFactory(this.gameObject);

factory.TweenRotation(new Vector3(45, 45, 0), 5, EasingType.Linear);

factory.StartTween();
```
### Tweening Position
```cs
TweenFactory factory = new TweenFactory(this.gameObject);

factory.TweenPosition(targetPosition, 5, EasingType.Linear);

factory.StartTween();
```

### Tweening Color
```cs
TweenFactory factory = new TweenFactory(this.gameObject);

factory.TweenColor(color, 20, EasingType.Linear);

factory.StartTween();
```

### Tweening multiple values at once

```cs
TweenFactory factory = new TweenFactory(this.gameObject);

factory.TweenPosition(targetPosition, 5, EasingType.Linear);
factory.TweenRotation(new Vector3(45, 45, 0), 5, EasingType.Linear);
factory.TweenScale(new Vector3(0.5f, 0.5f, 0.5f), 5, EasingType.Linear);

factory.StartTween();
```

### Working with tween events

```cs
TweenFactory factory = new TweenFactory(this.gameObject);

factory.TweenPosition(targetPosition, speed, easingType);

// Each tween type has his own onComplete event
factory.PositionTweenComplete = () =>
{
print("it seems like the position tween in this factory has finished");
};
            
// Invoked when all tweens in this factory completed.
factory.OnTweenComplete = () => { print("TWEEN FINISHED"); };

factory.StartTween();
```


## Easing types supported
    Linear
    EaseInSine
    EaseOutSine
    EaseInOutSine
    EaseInCubic
    EaseOutCubic
    EaseInOutCubic
    EaseInQuint
    EaseOutQuint
    EaseInOutQuint
    EaseInCirc
    EaseOutCirc
    EaseInOutCirc
    EaseInElastic
    EaseOutElastic
    EaseInOutElastic
    EaseInQuad
    EaseOutQuad
    EaseInOutQuad
    EaseInQuart
    EaseOutQuart
    EaseInOutQuart
    EaseInExpo
    EaseOutExpo
    EaseInOutExpo
    EaseInBack
    EaseOutBack
    EaseInOutBack
    EaseInBounce
    EaseOutBounce
    EaseInOutBounce

## License
[MIT](https://choosealicense.com/licenses/mit/)
