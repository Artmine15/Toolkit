namespace Artmine15.Utils.Toolkit.Enums
{
    public enum TimerType { None, Common, Coroutine, Repeatable };
    public enum TimerState { Active, Stopped };

    public enum FpsHandlerMode { Manual, ScreenRefreshRate }
    public enum FpsHandlerEncapsulation { ControlledByHandler, EditedByExternalClass }
}