using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesLogica : MonoBehaviour
{
    public float velocidad;
    public bool adentro = false;
    public Slider slider1; // Primer slider
    public Slider slider2; // Segundo slider

    void Start()
    {
        // Asegúrate de que los sliders tengan un valor inicial
        if (slider1 != null)
        {
            slider1.value = slider1.maxValue; // Opcional: Inicializar el primer slider al valor máximo
        }

        if (slider2 != null)
        {
            slider2.value = slider2.maxValue; // Opcional: Inicializar el segundo slider al valor máximo
        }
    }

    void Update()
    {
        // Cambiar movimiento a arriba y abajo
        transform.position += Vector3.down * velocidad * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F))
        {
            PressButton();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            adentro = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            adentro = false;
        }
    }

    public void PressButton()
    {
        // Si el objeto está dentro de "linea f", baja el valor de slider1
        if (adentro && slider1 != null)
        {
            slider1.value -= 1;
        }
        // Si el objeto está fuera de "linea f", baja el valor de slider2
        else if (!adentro && slider2 != null)
        {
            slider2.value -= 1;
        }
        Destroy(gameObject);
    }
}