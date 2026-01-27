# SimpleEasing
A simple script for easing animations in code, allowing you to apply easing dynamically.

## Using
#### Import the namespace:
```
using SimpleEasing;
```
#### Use the easing function:
###### Recommended value range: 0 to 1
```
float value = Ease.Easing(value, easeType);
```
#### Specify the easing type using the EaseType enum:
```
EaseType ease = EaseType.OutCirc;
```

## Editor support
- You can set the EaseType directly in the Inspector.
- A graph of the selected EaseType is displayed.

 
## Config
- Graph settings can be configured via the Config file in the package folder.
