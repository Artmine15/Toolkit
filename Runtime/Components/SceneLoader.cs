using UnityEngine;
using UnityEngine.SceneManagement;

namespace Artmine15.YGMusicBouncyBlock
{
    public class SceneLoader
    {
        public static void LoadScene(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }
    }
}
