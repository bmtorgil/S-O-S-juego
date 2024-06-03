using System.Collections;
using UnityEngine;
using TMPro; // Asegúrate de importar el namespace de TextMeshPro

namespace DialogueSystem
{
    public class LineaDialogo : MonoBehaviour
    {
        private TextMeshProUGUI textHolder; // Cambiado a TextMeshProUGUI
        [SerializeField] private string input;
        [SerializeField] private float textSpeed = 0.1f; // Ajusta la velocidad de escritura

        private void Awake()
        {
            textHolder = GetComponent<TextMeshProUGUI>(); // Cambiado a TextMeshProUGUI
            StartCoroutine(WriteText(input, textHolder));
        }

        private IEnumerator WriteText(string textToWrite, TextMeshProUGUI textHolder) // Cambiado a TextMeshProUGUI
        {
            textHolder.text = ""; // Asegúrate de que el TextMeshProUGUI esté vacío antes de comenzar

            foreach (char c in textToWrite)
            {
                textHolder.text += c; // Agrega cada caracter al texto
                yield return new WaitForSeconds(textSpeed); // Espera un momento antes de agregar el siguiente caracter
            }
        }
    }
}
