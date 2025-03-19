# My personal tools library

## Timer
Classes that help you quickly setup timer.
Value can be Increasing and Decreasing.
### Types
- Common - Basic timer, stop when ends.
- Repeatable - Repeat yourself when ends. Can be stopped manualy.
### Initialization
```csharp
private CommonTimer _commonTimer = new CommonTimer();
```
### Starting
```csharp
private float _time = 5;

private void Foo()
{
    _commonTimer.Start(_time, TimerGrowing.Increasing);
}
```
### Methods
- `Stop();`
- `Pause();`
- `Resume();`
- `GetValue();` - Return current timer value.
- `GetNormalizedValue();` - Return current timer normalized value, from 0 to 1 or vice versa.
### Events
- `OnTimerEnded` - all timers have.
- `OnTimerRepeated` - wher RepeateableTimer repeated.
### Properties
`IsActive` - bool, is timer active?

## SceneLoader
### Methods
- `LoadScene(int buildIndex);` - if some scene already loading this method will not work until load
- `ReloadScene();`
---
# Components

## Fps Controller
Has 3 modes
- Manual - Set your own fps manually.
- ScreenRefreshRate - Fps will be based on Screen.currentResolution.refreshRateRatio.value
- Maximum - Application.targetFrameRate = -1 or 999

## Follow Target
Moves object with that component to target. There are very simple usage and settings.
## RotationToTarget2D
Works with FollowTarget2D. Rotate object to target. Used very long time ago, so it may not work, I didn't check it.
