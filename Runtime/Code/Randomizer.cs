using UnityEngine;

namespace Artmine15.Utils.Toolkit.Code
{
    public static class Randomizer
    {
        public static bool IsTrueWithChanceOf(int percent, int maxChance = 100)
        {
            int num = Random.Range(0, maxChance + 1);
            if (num <= percent)
                return true;
            else
                return false;
        }
    }
}
