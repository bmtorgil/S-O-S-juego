using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogoController : MonoBehaviour
{
    public TextMeshProUGUI dialogoText;
    public TextMeshProUGUI dialogoTextOpcion2; // Nuevo texto
    public Image personajeImage;
    public AudioClip sonidoTecla;
    public float velocidadTexto = 0.05f;
    public GameObject panelDialogo; // Referencia al GameObject del panel de diálogo
    public GameObject fadePanel; // Panel de fundido a negro
    public float fadeDuration = 1.0f; // Duración del fundido
    [TextArea(3, 10)] public string[] dialogos;
    [TextArea(3, 10)] public string[] dialogosOpcion2; // Nuevos diálogos
    public Sprite[] personajes;
    public AudioClip[] audios; // Array de audios correspondientes a cada diálogo

    public Color[] coloresTextoOpcion2; // Arreglo de colores para el texto de la opción 2

    private AudioSource audioSource;
    private int indiceDialogo;
    private bool escribiendo;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on this GameObject.");
        }
        indiceDialogo = 0;
        OcultarDialogo();
        OcultarFadePanel();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !escribiendo)
        {
            if (indiceDialogo < dialogos.Length - 1) // Verificar si hay más diálogos disponibles
            {
                indiceDialogo++;
                MostrarDialogo();
            }
            else
            {
                StartCoroutine(FundidoYCambioDeEscena()); // Fundido a negro y cambio de escena
            }
        }
    }

    void OcultarDialogo()
    {
        dialogoText.gameObject.SetActive(false);
        dialogoTextOpcion2.gameObject.SetActive(false); // Ocultar el nuevo texto
        personajeImage.gameObject.SetActive(false);
        panelDialogo.SetActive(false); // Ocultar el panel de diálogo al inicio
    }

void MostrarDialogo()
{
    StartCoroutine(MostrarTexto(dialogos[indiceDialogo]));
    // Elimina la llamada a StartCoroutine para MostrarTextoOpcion2
    dialogoTextOpcion2.text = dialogosOpcion2[indiceDialogo]; // Mostrar el nuevo texto sin animación
    dialogoTextOpcion2.color = coloresTextoOpcion2[indiceDialogo]; // Asignar el color del texto de la opción 2
    personajeImage.sprite = personajes[indiceDialogo];
    ReproducirAudio();
    dialogoText.gameObject.SetActive(true);
    dialogoTextOpcion2.gameObject.SetActive(true); // Mostrar el nuevo texto
    personajeImage.gameObject.SetActive(true);
    panelDialogo.SetActive(true); // Mostrar el panel de diálogo
}


    void OcultarFadePanel()
    {
        Color color = fadePanel.GetComponent<Image>().color;
        color.a = 0;
        fadePanel.GetComponent<Image>().color = color;
        fadePanel.SetActive(false);
    }

    IEnumerator MostrarTexto(string texto)
    {
        escribiendo = true;
        dialogoText.text = "";
        foreach (char letra in texto.ToCharArray())
        {
            dialogoText.text += letra;
            if (sonidoTecla != null)
            {
                audioSource.PlayOneShot(sonidoTecla);
            }
            yield return new WaitForSeconds(velocidadTexto);
        }
        escribiendo = false;
    }

    IEnumerator MostrarTextoOpcion2(string texto)
    {
        escribiendo = true;
        dialogoTextOpcion2.text = "";
        foreach (char letra in texto.ToCharArray())
        {
            dialogoTextOpcion2.text += letra;
            yield return new WaitForSeconds(velocidadTexto);
        }
        escribiendo = false;
    }

    void ReproducirAudio()
    {
        if (audios != null && audios.Length > indiceDialogo && audioSource != null)
        {
            audioSource.clip = audios[indiceDialogo];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No audio clip found for the current dialog index or AudioSource is null.");
        }
    }

    IEnumerator FundidoYCambioDeEscena()
    {
        fadePanel.SetActive(true);
        Image fadeImage = fadePanel.GetComponent<Image>();
        Color color = fadeImage.color;
        float startAlpha = color.a;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float blend = Mathf.Clamp01(t / fadeDuration);
            color.a = Mathf.Lerp(startAlpha, 1.0f, blend);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1.0f;
        fadeImage.color = color;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    
}
