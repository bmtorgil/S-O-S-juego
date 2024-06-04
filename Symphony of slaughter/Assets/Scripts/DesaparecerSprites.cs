using UnityEngine;
using UnityEngine.UI;

public class DesaparecerSprites : MonoBehaviour
{
    public Slider slider; // Asigna el Slider en el Inspector
    public GameObject spriteGameObject; // Asigna el GameObject que contiene el SpriteRenderer en el Inspector

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Obtener el componente SpriteRenderer del GameObject
        spriteRenderer = spriteGameObject.GetComponent<SpriteRenderer>();

        // Asegúrate de que el slider tenga un valor de 0 a 1
        slider.minValue = 0;
        slider.maxValue = 100;

        // Añade un listener para cuando el valor del slider cambie
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        // Verifica si el slider está al 50% vacío (50% del valor máximo)
        if (value <= 0.5f)
        {
            // Hacer el sprite 99% transparente
            Color color = spriteRenderer.color;
            color.a = 0.01f; // 1% de opacidad (99% de transparencia)
            spriteRenderer.color = color;
        }
        else
        {
            // Hacer el sprite completamente opaco (o ajustar a otro valor si es necesario)
            Color color = spriteRenderer.color;
            color.a = 1f; // 100% de opacidad
            spriteRenderer.color = color;
        }
    }
}

