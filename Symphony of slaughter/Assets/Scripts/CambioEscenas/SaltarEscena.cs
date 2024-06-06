using UnityEngine.SceneManagement;
using UnityEngine;

public class SaltarEscena : MonoBehaviour
{
    public void CambiarAEscenaSiguiente()
    {
        int siguienteIndiceEscena = SceneManager.GetActiveScene().buildIndex + 1;
        if (siguienteIndiceEscena < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(siguienteIndiceEscena);
        }
        else
        {
            Debug.LogWarning("No hay más escenas disponibles.");
        }
    }
}
