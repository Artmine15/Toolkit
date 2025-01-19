using UnityEngine.SceneManagement;

namespace Artmine15.Packages.Utils.Toolkit.Code
{
    public static class SceneLoader
    {
        private static bool _isSceneLoading;

        public static void LoadScene(int buildIndex)
        {
            if (_isSceneLoading == true) return;
            else DisableLoading();

            SceneManager.LoadScene(buildIndex);
        }

        public static void ReloadScene()
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private static void EnableLoading(Scene scene, LoadSceneMode loadSceneMode)
        {
            _isSceneLoading = false;
            SceneManager.sceneLoaded -= EnableLoading;
        }

        private static void DisableLoading()
        {
            _isSceneLoading = true;
            SceneManager.sceneLoaded += EnableLoading;
        }
    }
}
