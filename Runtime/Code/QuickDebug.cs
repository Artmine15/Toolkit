using UnityEngine;

namespace Artmine15.Utils.Toolkit.Code
{
    public static class QuickDebug
    {
        public static void KeyNumLog(params object[] args)
        {
            //Example: KEY: NUM
            if (args.Length < 2)
            {
                Debug.LogError("Not enough parameters. Fill in minimum 2");
                return;
            }

            string log = "";
            string label;
            string number;
            for (int i = 0; i < args.Length; i += 2)
            {
                label = args[i].ToString();
                number = args[i + 1].ToString();
                log += $"{label}: {number}";

                if (i < args.Length - 2)
                    log += $", ";
            }
            Debug.Log(log);
        }

        public static void VectorLog(string label, Vector2 vector2)
        {
            Debug.Log($"{label}: x:{vector2.x}, y:{vector2.y}");
        }

        public static void VectorLog(string label, Vector3 vector3)
        {
            Debug.Log($"{label}: x:{vector3.x}, y:{vector3.y}, z:{vector3.z}");
        }
    }
}
