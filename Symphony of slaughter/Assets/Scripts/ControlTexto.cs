using System.Collections;
using UnityEngine;
using TMPro;

public class ControlTexto : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public float velocidadDesplazamiento = 12f; // Velocidad de desplazamiento del texto

    void Start()
    {
        // Inicia la corutina para mostrar, desplazar y ocultar el texto
        StartCoroutine(MostrarDesplazarYDesvanecerTexto());
    }

    IEnumerator MostrarDesplazarYDesvanecerTexto()
    {
        // Muestra el texto
        texto.enabled = true;

        float tiempoInicio = Time.time; // Tiempo de inicio de la corutina

        // Bucle mientras el tiempo transcurrido sea menor que 3 segundos
        while (Time.time - tiempoInicio < 3f)
        {
            // Desplaza gradualmente el texto hacia arriba
            texto.rectTransform.anchoredPosition += Vector2.up * velocidadDesplazamiento * Time.deltaTime;

            yield return null; // Espera un frame
        }

        // Desvanece gradualmente el texto
        float alpha = 1f;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime / 2f; // Ajusta la velocidad del desvanecimiento cambiando el divisor
            texto.alpha = alpha;
            yield return null;
        }

        // Desactiva el texto después de que se desvanezca
        texto.enabled = false;
    }
}