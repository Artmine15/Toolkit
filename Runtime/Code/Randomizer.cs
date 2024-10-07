using UnityEngine;

namespace Artmine15.Utils.Toolkit.Code
{
    public static class Randomizer
    {
        public static bool IsTrueWithChanceOf(float percent, float maxChance = 100)
        {
            float num = Random.Range(0, maxChance);
            if (num <= percent)
                return true;
            else
                return false;
        }
    }
}
