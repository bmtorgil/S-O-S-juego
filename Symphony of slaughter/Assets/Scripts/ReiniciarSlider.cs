using UnityEngine;
using UnityEngine.UI;

public class ReiniciarSlider : MonoBehaviour
{
    public Slider slider2; // Referencia al slider2
    public Slider slider3; // Referencia al slider3

    void Start()
    {
        // Agrega un listener al evento onValueChanged de slider2
        slider2.onValueChanged.AddListener(delegate { OnSlider2ValueChanged(); });
    }

    void OnSlider2ValueChanged()
    {
        // Verifica si slider2 ha bajado su valor en una unidad
        if (slider2.value < slider2.maxValue)
        {
            // Reinicia slider3
            slider3.value = 0.00000001f;
        }
    }
}