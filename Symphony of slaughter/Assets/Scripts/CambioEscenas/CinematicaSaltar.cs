using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CinematicaSaltar : MonoBehaviour
{
    public Button yourButton; // Referencia al botón
    public string sceneName; // Nombre de la escena a la que deseas cambiar

    void Start()
    {
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogError("Button reference is missing.");
        }
    }

    void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is not specified.");
        }
    }
}
