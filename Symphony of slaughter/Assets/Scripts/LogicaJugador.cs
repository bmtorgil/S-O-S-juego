using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicaJugador : MonoBehaviour
{
    public int puntuacion = 0;
    public TextMeshProUGUI texto;
    public int contador = 0;
    public bool adentro = false;
    private SpriteRenderer imageRenderer; // Referencia al componente SpriteRenderer de la imagen hija
    private Color originalColor; // Guardar el color original de la imagen
    private bool objetoEncima = false; // Variable para verificar si hay un objeto encima

    void Start()
    {
        texto = GameObject.Find("ScoreUI").GetComponent<TextMeshProUGUI>();
        imageRenderer = GetComponentInChildren<SpriteRenderer>(); // Obtener el componente SpriteRenderer del hijo

        // Guardar el color original de la imagen
        if (imageRenderer != null)
        {
            originalColor = imageRenderer.color;
        }
    }

    void Update()
    {
        // Cambiar el estado de 'adentro' basado en el valor de contador
        adentro = (contador == 2);

        // Verificar si la tecla "F" está presionada y hay un objeto encima
        if (Input.GetKey(KeyCode.F) && objetoEncima)
        {
            OscurecerImagen();
        }
        else
        {
            RestaurarColorOriginal();
        }
    }

    void OscurecerImagen()
    {
        // Hacer la imagen más oscura mientras la tecla "F" esté presionada y haya un objeto encima
        if (imageRenderer != null)
        {
            Color colorActual = imageRenderer.color;
            colorActual.a = 0.5f; // Ajustar la transparencia al 50%
            imageRenderer.color = colorActual;
        }
    }

    void RestaurarColorOriginal()
    {
        // Restaurar el color original de la imagen
        if (imageRenderer != null)
        {
            imageRenderer.color = originalColor;
        }
    }

    // Métodos para detectar colisiones
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("flecha")) // Verificar si el objeto tiene el tag "Interactable"
        {
            objetoEncima = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("flecha")) // Verificar si el objeto tiene el tag "Interactable"
        {
            objetoEncima = false;
        }
    }
}
