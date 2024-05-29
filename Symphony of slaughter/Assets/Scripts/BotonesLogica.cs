using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesLogica : MonoBehaviour
{
    public float velocidad;
    public KeyCode tecla; // Tecla asociada al botón
    public Slider slider1; // Primer slider

    private static List<BotonesLogica> botonesActivos = new List<BotonesLogica>(); // Lista de botones activos
    private bool adentro = false;

    void Start()
    {
        // Asegúrate de que los sliders tengan un valor inicial
        if (slider1 != null)
        {
            slider1.value = slider1.maxValue;
        }
    }

    void Update()
    {
        // Movimiento de arriba a abajo
        transform.position += Vector3.down * velocidad * Time.deltaTime;

        if (Input.GetKeyDown(tecla))
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
        // Si este botón está dentro del área y no está en la lista de botones activos, agrégalo a la lista
        if (adentro && slider1 != null && !botonesActivos.Contains(this))
        {
            botonesActivos.Add(this);
            slider1.value -= 1;
            Destroy(gameObject);
        }
    }
}