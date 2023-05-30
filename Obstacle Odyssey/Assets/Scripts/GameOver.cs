using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        // Cargar el archivo de audio desde la carpeta Resources
        AudioClip audioClip = Resources.Load<AudioClip>("lose");
        // Asignar el audio clip al AudioSource
        audioSource.clip = audioClip;
        // Reproducir el audio
        audioSource.Play();
    }

    private void OnDestroy()
    {
        // Detener el audio al salir de la pantalla
        audioSource.Stop();
    }

    public void Retry(string sceneName)
    {
        // Detener el audio antes de cambiar de escena
        audioSource.Stop();
        SceneManager.LoadScene(sceneName);
    }

    public void GoMainMenu(string sceneName)
    {
        // Detener el audio antes de cambiar de escena
        audioSource.Stop();
        SceneManager.LoadScene(sceneName);
    }
}