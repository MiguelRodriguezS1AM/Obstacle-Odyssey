using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Retry(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoMainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
