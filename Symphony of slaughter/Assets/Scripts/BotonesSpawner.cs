using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesSpawner : MonoBehaviour
{
    public GameObject botonF;
    public GameObject botonG;
    public GameObject botonH;
    public GameObject botonJ;

    public Transform puntoAparicionF;
    public Transform puntoAparicionG;
    public Transform puntoAparicionH;
    public Transform puntoAparicionJ;

    public float velocidadBoton;

    [System.Serializable]
    public class BotonAparicion
    {
        public string tipoBoton;
        public float tiempo;
    }

    public List<BotonAparicion> ordenAparicion;

    private void Awake()
    {
        // Inicializa la lista de apariciones con 15 botones de cada tipo
        ordenAparicion = new List<BotonAparicion>();

        // Asumiendo que quieres que aparezcan en intervalos de 1 segundo para simplificar
        float tiempoBase = 1.0f;

        for (int i = 0; i < 15; i++)
        {
            ordenAparicion.Add(new BotonAparicion { tipoBoton = "F", tiempo = tiempoBase * (i + 1) });
            ordenAparicion.Add(new BotonAparicion { tipoBoton = "G", tiempo = tiempoBase * (i + 1 + 5) });
            ordenAparicion.Add(new BotonAparicion { tipoBoton = "H", tiempo = tiempoBase * (i + 1 + 10) });
            ordenAparicion.Add(new BotonAparicion { tipoBoton = "J", tiempo = tiempoBase * (i + 1 + 15) });
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnBotones());
    }

    private IEnumerator SpawnBotones()
    {
        foreach (var aparicion in ordenAparicion)
        {
            yield return new WaitForSeconds(aparicion.tiempo);

            GameObject prefab = null;
            Transform puntoAparicion = null;

            switch (aparicion.tipoBoton)
            {
                case "F":
                    prefab = botonF;
                    puntoAparicion = puntoAparicionF;
                    break;
                case "G":
                    prefab = botonG;
                    puntoAparicion = puntoAparicionG;
                    break;
                case "H":
                    prefab = botonH;
                    puntoAparicion = puntoAparicionH;
                    break;
                case "J":
                    prefab = botonJ;
                    puntoAparicion = puntoAparicionJ;
                    break;
            }

            if (prefab != null && puntoAparicion != null)
            {
                GameObject boton = Instantiate(prefab, puntoAparicion.position, Quaternion.identity);
                boton.GetComponent<BotonesLogica>().velocidad = velocidadBoton;
            }
        }
    }
}