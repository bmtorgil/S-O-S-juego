using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesLogica : MonoBehaviour
{
    public float velocidad;
    public int contador = 0;
    public bool adentro = false;
    public Slider slider; // Referencia al slider

    void Start()
    {
        // Asegúrate de que el slider tenga un valor inicial
        if (slider != null)
        {
            slider.value = slider.maxValue; // Opcional: Inicializar el slider al valor máximo
        }
    }

    void Update()
    {
        // Cambiar movimiento a arriba y abajo
        transform.position += Vector3.down * velocidad * Time.deltaTime;

        if (contador == 2)
        {
            adentro = true;
        }
        else
        {
            adentro = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (adentro)
            {
                // Aquí disminuimos el slider si el objeto está sobre la línea F y se pulsa la tecla F
                if (slider != null)
                {
                    slider.value -= 1; // Decrementar el valor del slider
                }

                LogicaJugador logicaJugador = GameObject.Find("linea f").GetComponent<LogicaJugador>();
                if (logicaJugador != null)
                {
                    logicaJugador.puntuacion++;
                    logicaJugador.texto.text = "score: " + logicaJugador.puntuacion.ToString();
                }
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            contador++;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            contador--;
        }
    }
}