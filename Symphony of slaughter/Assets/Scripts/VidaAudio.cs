using UnityEngine;
using UnityEngine.UI;

public class VidaAudio : MonoBehaviour
{
    public Slider slider; // Referencia al Slider
    public AudioSource audioSource; // Referencia al AudioSource

    private float previousValue; // Almacena el valor anterior del slider

    void Start()
    {
        if (slider != null)
        {
            previousValue = slider.value; // Inicializa el valor anterior con el valor actual del slider
            slider.onValueChanged.AddListener(OnSliderValueChanged); // Agrega el listener al evento onValueChanged
        }

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void OnSliderValueChanged(float value)
    {
        if (value < previousValue && audioSource != null) // Solo reproduce el sonido si el valor disminuye
        {
            audioSource.Play();
        }
        previousValue = value; // Actualiza el valor anterior con el nuevo valor
    }
}
