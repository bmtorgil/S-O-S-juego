using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenasPerder : MonoBehaviour
{
    // Función para cargar una escena por su nombre
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
