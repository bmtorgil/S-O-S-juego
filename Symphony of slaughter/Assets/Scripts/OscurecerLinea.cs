using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscurecerLinea : MonoBehaviour
{
    public KeyCode tecla; // Tecla asociada al objeto
    private Renderer objetoRenderer; // Renderer del objeto
    private Color originalColor; // Color original del objeto
    private bool teclaPresionada = false; // Indica si la tecla está siendo presionada

    void Start()
    {
        // Obtener el componente Renderer del objeto
        objetoRenderer = GetComponent<Renderer>();

        // Guardar el color original del objeto
        originalColor = objetoRenderer.material.color;
    }

    void Update()
    {
        // Verificar si se presiona la tecla
        if (Input.GetKeyDown(tecla))
        {
            teclaPresionada = true;
        }

        // Verificar si se suelta la tecla
        if (Input.GetKeyUp(tecla))
        {
            teclaPresionada = false;
        }

        // Si la tecla está presionada, oscurecer el color del objeto
        if (teclaPresionada)
        {
            Oscurecer();
        }
        else // Si la tecla no está presionada, restaurar el color original del objeto
        {
            RestaurarColor();
        }
    }

    // Función para oscurecer el color del objeto
    void Oscurecer()
    {
        Color nuevoColor = originalColor;
        nuevoColor.r *= 0.5f; // Reducir el componente de rojo a la mitad
        nuevoColor.g *= 0.5f; // Reducir el componente de verde a la mitad
        nuevoColor.b *= 0.5f; // Reducir el componente de azul a la mitad
        objetoRenderer.material.color = nuevoColor; // Aplicar el nuevo color al objeto
    }

    // Función para restaurar el color original del objeto
    void RestaurarColor()
    {
        objetoRenderer.material.color = originalColor; // Restaurar el color original del objeto
    }
}
