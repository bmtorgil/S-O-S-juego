using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Demonio1 : MonoBehaviour
{
    public Slider slider;
    public Slider slider2; // Referencia al segundo slider
    public GameObject spriteObject; // Referencia al GameObject que contiene el sprite
    public GameObject imagenObject; // Referencia al GameObject que contiene la imagen
    public AudioSource audioSource; // Referencia al AudioSource

    private bool isShowingSprite = true; // Variable para controlar si se muestra el sprite o la imagen
    private bool sliderAtZero = false; // Variable para controlar si el slider está en 0 por primera vez
    private bool audioPlayed = false; // Variable para controlar si el audio ya ha sido reproducido
    private float startTime; // Tiempo de inicio de la escena

    void Start()
    {
        startTime = Time.time; // Guardar el tiempo de inicio de la escena

        // Asegurar que los objetos estén inicialmente ocultos
        spriteObject.SetActive(false);
        imagenObject.SetActive(false);
    }

    void Update()
    {
        // Verificar si han pasado al menos 7 segundos desde el inicio de la escena
        if (Time.time - startTime >= 7)
        {
            if (slider != null && slider2 != null)
            {
                // Verificar si slider2 está al menos al 50% vacío
                if (slider2.value <= slider2.maxValue * 0.5f)
                {
                    // Activar los objetos si están ocultos
                    if (!spriteObject.activeSelf && !imagenObject.activeSelf)
                    {
                        spriteObject.SetActive(true);
                    }

                    // Verificar si slider ha alcanzado el valor deseado (en este caso, 0)
                    if (slider.value == 0 && !sliderAtZero)
                    {
                        // Cambiar entre sprite e imagen
                        if (isShowingSprite)
                        {
                            StartCoroutine(ShowImageForHalfSecond());
                        }

                        // Reproducir el audio si aún no se ha reproducido en este ciclo
                        if (!audioPlayed)
                        {
                            if (audioSource != null)
                            {
                                audioSource.Play();
                            }
                            audioPlayed = true; // Marcar que el audio ya se ha reproducido
                        }
                    }
                    else if (slider.value > 0)
                    {
                        sliderAtZero = false; // Marcar que ya no está en 0 por primera vez
                        audioPlayed = false; // Resetear la variable de audio cuando el slider no está en 0
                    }
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

        // Esperar a que pase medio segundo
        yield return new WaitForSeconds(0.3f);

        // Ocultar la imagen y mostrar el sprite
        imagenObject.SetActive(false);
        spriteObject.SetActive(true);

        isShowingSprite = true;
    }
}
