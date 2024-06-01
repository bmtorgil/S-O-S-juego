 using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Demonio : MonoBehaviour
{
    public Slider slider;
    public GameObject spriteObject; // Referencia al GameObject que contiene el sprite
    public GameObject imagenObject; // Referencia al GameObject que contiene la imagen

    private bool isShowingSprite = true; // Variable para controlar si se muestra el sprite o la imagen
    private bool sliderAtZero = false; // Variable para controlar si el slider está en 0 por primera vez
    private float startTime; // Tiempo de inicio de la escena

    void Start()
    {
        startTime = Time.time; // Guardar el tiempo de inicio de la escena
    }

    void Update()
    {
        // Verificar si han pasado al menos 4 segundos desde el inicio de la escena
        if (Time.time - startTime >= 5)
        {
            if (slider != null)
            {
                // Verificar si slider ha alcanzado el valor deseado (en este caso, 0)
                if (slider.value == 0 && !sliderAtZero)
                {
                    // Cambiar entre sprite e imagen
                    if (isShowingSprite)
                    {
                        StartCoroutine(ShowImageForHalfSecond());
                    }
                }
                else
                {
                    sliderAtZero = false; // Marcar que ya no está en 0 por primera vez
                }
            }
        }
    }

    IEnumerator ShowImageForHalfSecond()
    {
        isShowingSprite = false;

        // Ocultar el sprite y mostrar la imagen
        spriteObject.SetActive(false);
        imagenObject.SetActive(true);

        // Esperar medio segundo
        yield return new WaitForSeconds(0.5f);

        // Ocultar la imagen y mostrar el sprite
        imagenObject.SetActive(false);
        spriteObject.SetActive(true);

        isShowingSprite = true;
    }
}