using UnityEngine;
using UnityEngine.UI;

public class JMenuController : MonoBehaviour
{
    public GameObject menuInicial;
    public GameObject panelOpciones;
    private bool isMenuShown = false;
    private float initialTimeScale;

    void Start()
    {
        // Asegúrate de que el menú de opciones esté desactivado al inicio
        panelOpciones.SetActive(false);
        initialTimeScale = Time.timeScale;
    }

    public void MostrarPanelOpciones()
    {
        // Detener la escena
        Time.timeScale = 0f;

        // Detener la música
        AudioListener.pause = true;

        // Mostrar el panel de opciones
        menuInicial.SetActive(false);
        panelOpciones.SetActive(true);

        isMenuShown = true;
    }

    public void VolverAMenuInicial()
    {
        // Reanudar la escena
        Time.timeScale = initialTimeScale;

        // Reanudar la música
        AudioListener.pause = false;

        // Ocultar el panel de opciones
        panelOpciones.SetActive(false);
        menuInicial.SetActive(true);

        isMenuShown = false;
    }

    void Update()
    {
        // Si el menú está mostrado y se presiona la tecla ESC, volver al menú inicial
        if (isMenuShown && Input.GetKeyDown(KeyCode.Escape))
        {
            VolverAMenuInicial();
        }
    }
}
