using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManagement

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
