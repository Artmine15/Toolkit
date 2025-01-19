using System;

namespace Artmine15.Packages.Utils.Toolkit
{
    public enum TimerType { None, Common, Coroutine, Repeatable };
    public enum TimerGrowing { Increasing, Decreasing };

    public enum MovementType { NoDelay, Lerp, MoveTowards }
    public enum MovementAxis { X = MovementAxisFlags.X, Y = MovementAxisFlags.Y, Z = MovementAxisFlags.Z }
    [Flags]
    public enum MovementAxisFlags { X = 1, Y = 2, Z = 4 }
    public enum RotationType { UseDefault, NoDelay, Lerp }

    public enum FpsHandlerMode { Manual, ScreenRefreshRate, Maximum }
    public enum FpsHandlerEncapsulation { ControlledByHandler, EditedByExternalClass }
}