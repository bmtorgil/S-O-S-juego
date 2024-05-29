using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BotonesControl : MonoBehaviour
{
    public List<Button>[] botones; // Lista de botonesF, botonesG, botonesH y botonesJ
    private int[] indicesBotonActivo; // Índices de botón activo para cada lista

    void Start()
    {
        // Inicializa las listas y los índices
        botones = new List<Button>[4];
        indicesBotonActivo = new int[4];

        for (int i = 0; i < 4; i++)
        {
            botones[i] = new List<Button>();
            indicesBotonActivo[i] = 0;
        }

        // Encuentra y guarda todos los botonesF, botonesG, botonesH y botonesJ en las listas correspondientes
        Button[] allButtons = FindObjectsOfType<Button>();
        foreach (Button button in allButtons)
        {
            if (button.name.StartsWith("BotonF"))
            {
                botones[0].Add(button);
            }
            else if (button.name.StartsWith("BotonG"))
            {
                botones[1].Add(button);
            }
            else if (button.name.StartsWith("BotonH"))
            {
                botones[2].Add(button);
            }
            else if (button.name.StartsWith("BotonJ"))
            {
                botones[3].Add(button);
            }
        }

        // Desactiva todos los botones excepto el primero de cada lista
        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j < botones[i].Count; j++)
            {
                botones[i][j].gameObject.SetActive(false);
            }
        }
    }

    public void PulsarBoton(int indice)
    {
        // Desactiva el botón actual
        botones[indice][indicesBotonActivo[indice]].gameObject.SetActive(false);

        // Incrementa el índice y vuelve al principio si se llega al final
        indicesBotonActivo[indice] = (indicesBotonActivo[indice] + 1) % botones[indice].Count;

        // Activa el siguiente botón en la lista correspondiente
        botones[indice][indicesBotonActivo[indice]].gameObject.SetActive(true);
    }
}