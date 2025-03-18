using System;

namespace Artmine15.Toolkit
{
    public enum TimerGrowing { Increasing, Decreasing };

    public enum MovementType { NoDelay, Lerp, MoveTowards }
    public enum RotationType { UseDefault, NoDelay, Lerp }

    public enum MovementAxis { X = MovementAxisFlags.X, Y = MovementAxisFlags.Y, Z = MovementAxisFlags.Z }
    [Flags]
    public enum MovementAxisFlags { X = 1, Y = 2, Z = 4 }

    public enum MovementAxis2D { X = MovementAxisFlags2D.X, Y = MovementAxisFlags2D.Y }
    [Flags]
    public enum MovementAxisFlags2D { X = 1, Y = 2 }
    public enum UpdateMethod { Update, FixedUpdate, LateUpdate }

    public enum FpsControllerMode { Manual, ScreenRefreshRate, Maximum }
    public enum FpsHandlerEncapsulation { ControlledByHandler, EditedByExternalClass }
}