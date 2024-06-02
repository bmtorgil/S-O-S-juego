using UnityEngine;
using UnityEngine.UI;

public class Perder : MonoBehaviour
{
    public Slider slider;
    public Canvas endCanvas;
    public GameObject animatedSprite;
    private bool animationPlayed = false;

    void Start()
    {
        // Asegúrate de que el canvas esté oculto al inicio
        endCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        // Verificar si el slider ha llegado a 0
        if (slider.value <= 0 && !animationPlayed)
        {
            PauseSceneExceptSprite();
            ShowEndCanvas();
            PlaySpriteAnimation();
            animationPlayed = true;
        }
    }

    void PauseSceneExceptSprite()
    {
        // Pausar todo menos el tiempo real
        Time.timeScale = 0f;
    }

    void ShowEndCanvas()
    {
        // Mostrar el canvas
        endCanvas.gameObject.SetActive(true);
    }

    void PlaySpriteAnimation()
    {
        // Reproducir la animación del sprite solo una vez
        Animator animator = animatedSprite.GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("sprites intestino_0", 7, 0);
        }
    }
}
