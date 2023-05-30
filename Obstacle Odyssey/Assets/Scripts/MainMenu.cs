using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        // Cargar el archivo de audio desde la carpeta Resources
        AudioClip audioClip = Resources.Load<AudioClip>("Menu_Music");
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

    public void GoToScene(string sceneName)
    {
        // Detener el audio antes de cambiar de escena
        audioSource.Stop();
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp()
    {
        // Detener el audio antes de salir de la aplicación
        audioSource.Stop();
        Application.Quit();
        Debug.Log("Application has quit.");
    }
}