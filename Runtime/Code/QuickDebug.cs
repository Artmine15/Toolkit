using UnityEngine;

namespace Artmine15.Toolkit
{
    public static class QuickDebug
    {
        /// <summary>
        /// Print: KEY: NUM, KEY: NUM... in the Unity console
        /// </summary>
        /// <param name="args"></param>
        public static void KeyNumLog(params object[] args)
        {
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
    }
}
