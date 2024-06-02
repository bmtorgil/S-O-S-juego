using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource; // El AudioSource que reproducirá el sonido

    void Start()
    {
        // Asegúrate de que el AudioSource esté asignado
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Esta función se llamará desde el evento de animación
    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
