using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    public GameObject pauseMenuUI;
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
    }

    void Pause()
    {
        // Activar el menú de pausa y detener el tiempo
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Restart()
    {
        // Reiniciar la escena actual
        Time.timeScale = 1f; // Asegurarse de que el tiempo esté corriendo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        // Salir del juego
        Debug.Log("Quit Game");
        Application.Quit();
    }
}