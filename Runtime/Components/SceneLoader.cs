using UnityEngine.SceneManagement;

namespace Artmine15.Utils.Toolkit.Components
{
    public class SceneLoader
    {
        public static void LoadScene(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }

        public static void ReloadScene(int buildIndex)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
