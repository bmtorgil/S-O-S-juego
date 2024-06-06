using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OscurecerLinea : MonoBehaviour
{
    public KeyCode teclaCorrespondiente; // La tecla que corresponde a esta línea
    public Image imagen; // Referencia a la imagen correspondiente
    private Color originalColor; // Guardar el color original de la imagen
    private bool objetoEncima = false; // Variable para verificar si hay un objeto encima
    private GameObject objetoActual; // Referencia al objeto actual que está encima

    void Start()
    {
        if (imagen != null)
        {
            originalColor = imagen.color; // Guardar el color original de la imagen
        }
        else
        {
            Debug.LogError("No se encontró el componente Image asignado.");
        }
    }

    void Update()
    {
        if (Input.GetKey(teclaCorrespondiente) && objetoEncima)
        {
            if (objetoActual != null)
            {
                Destroy(objetoActual);
                objetoActual = null;
                objetoEncima = false;
                OscurecerImagen();
                Debug.Log("Botón destruido y línea oscurecida.");
            }
        }
        else if (!Input.GetKey(teclaCorrespondiente))
        {
            RestaurarColorOriginal();
        }
    }

    void OscurecerImagen()
    {
        if (imagen != null)
        {
            imagen.color = new Color(originalColor.r * 0.5f, originalColor.g * 0.5f, originalColor.b * 0.5f, originalColor.a); // Oscurecer la imagen
        }
    }

    void RestaurarColorOriginal()
    {
        if (imagen != null)
        {
            imagen.color = originalColor;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("flecha"))
        {
            objetoEncima = true;
            objetoActual = other.gameObject;
            Debug.Log("Objeto entró en la línea: " + other.gameObject.name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("flecha"))
        {
            objetoEncima = false;
            objetoActual = null;
            Debug.Log("Objeto salió de la línea: " + other.gameObject.name);
        }
    }
}
