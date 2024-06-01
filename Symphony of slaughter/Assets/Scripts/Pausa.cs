using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public AudioSource musicAudioSource; // Referencia al componente de audio que reproduce la música
    private bool isPaused = false;

    void Start()
    {
        // Asegúrate de que el menú de pausa esté desactivado al inicio
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        // Detectar si se presiona la tecla ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // Desactivar el menú de pausa y reanudar el tiempo
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // Reanudar la música si estaba pausada
        if (musicAudioSource != null)
        {
            musicAudioSource.UnPause();
        }
    }

    void Pause()
    {
        // Activar el menú de pausa y detener el tiempo
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // Pausar la música si está reproduciendo
        if (musicAudioSource != null && musicAudioSource.isPlaying)
        {
            musicAudioSource.Pause();
        }
    }

    public void Restart()
    {
        // Reiniciar la primera escena
        Time.timeScale = 1f; // Asegurarse de que el tiempo esté corriendo
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        // Volver al menú inicial (primera escena)
        SceneManager.LoadScene(0);
    }
}
