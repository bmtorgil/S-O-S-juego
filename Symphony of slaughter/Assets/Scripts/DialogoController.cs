using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogoController : MonoBehaviour
{
    public TextMeshProUGUI dialogoText;
    public Image personajeImage;
    public AudioClip sonidoTecla;
    public float velocidadTexto = 0.05f;
    [TextArea(3, 10)] public string[] dialogos; // Hacer los diálogos editables desde el Inspector
    public Sprite[] personajes; // Array de imágenes de personajes

    private AudioSource audioSource;
    private int indiceDialogo;
    private bool escribiendo;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        indiceDialogo = 0;
        if (dialogos.Length > 0)
        {
            StartCoroutine(MostrarTexto(dialogos[indiceDialogo]));
            personajeImage.sprite = personajes[indiceDialogo]; // Mostrar la primera imagen
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !escribiendo)
        {
            indiceDialogo++;
            if (indiceDialogo < dialogos.Length)
            {
                StartCoroutine(MostrarTexto(dialogos[indiceDialogo]));
                personajeImage.sprite = personajes[indiceDialogo]; // Cambiar la imagen
            }
        }
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
}
