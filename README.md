# SimpleEasing

A simple script for easing animations in code, allowing you to apply easing dynamically.

---

## Using

### Import the namespace

```csharp
using SimpleEasing;
```

### Use the easing function

> The `value` must be normalized to work properly.

```csharp
float easeT = Ease.Easing(value, easeType);
```

### Specify the easing type using the EaseType enum

```csharp
EaseType ease = EaseType.OutCirc;
```

---

## Editor Support

- You can set the `EaseType` directly in the Inspector.  
- A graph of the selected `EaseType` is displayed for visualization.

---

## Config

- Graph settings can be configured via the `Config` file located in the package folder.
