using UnityEngine;

public class HasPerdido : MonoBehaviour
{
    public GameObject objectToShow; // Arrastra aquí el GameObject desde el Inspector
    public GameObject canvas;

    void Start()
    {
        // Asegúrate de que el GameObject esté desactivado al inicio
        if (objectToShow != null)
        {
            objectToShow.SetActive(false);
        }
    }

    // Esta función se llamará desde el evento de animación
    public void ShowGameObject()
    {
        if (objectToShow != null)
        {
            objectToShow.SetActive(true);
        }
    }
        public void ShowCanvas()
    {
        canvas.SetActive(true);
    }
}
