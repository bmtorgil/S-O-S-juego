using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlEscena : MonoBehaviour
{
    public float delay = 3f; // Tiempo de espera en segundos

    void Start()
    {
        // Iniciar la corrutina para cambiar de escena después de un retraso
        StartCoroutine(ChangeSceneAfterDelay());
    }

    IEnumerator ChangeSceneAfterDelay()
    {
        // Esperar por el tiempo especificado
        yield return new WaitForSeconds(delay);

        // Obtener el índice de la escena actual y calcular el índice de la siguiente escena
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Si la próxima escena está dentro del rango de escenas en el build settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Cargar la siguiente escena
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Si estamos en la última escena, cargar la primera escena (opcional)
            SceneManager.LoadScene(0);
        }
    }
}