using TDS.Infrastructure.Locator;
using UnityEngine.SceneManagement;

namespace TDS.Services.SceneLoading
{
    public class SceneLoadingService : IService
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}