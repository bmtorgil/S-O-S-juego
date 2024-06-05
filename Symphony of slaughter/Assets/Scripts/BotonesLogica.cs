using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesLogica : MonoBehaviour
{
    public float velocidad;
    public KeyCode tecla; // Tecla asociada al botón
    public Slider slider1; // Primer slider
    public Slider slider3; // Segundo slider
    

    private static List<BotonesLogica> botonesActivos = new List<BotonesLogica>(); // Lista de botones activos
    private bool adentro = false;

    void Start()
    {
        // Asegúrate de que los sliders tengan un valor inicial
        if (slider1 != null)
        {
            slider1.value = slider1.maxValue;
        }
        if (slider3 != null)
        {
            slider3.value = 0;
        }
    }

    void Update()
    {
        
        transform.position += Vector3.down * (velocidad * 1) * Time.deltaTime;

        
        if (transform.position.y <= Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height / 1.7f, 0)).y)
        {
           
            switch (tecla)
            {
                case KeyCode.F:
                    transform.position += Vector3.left * (velocidad * 0.4f) * Time.deltaTime; // Izquierda
                    break;
                case KeyCode.G:
                    transform.position += Vector3.left * (velocidad * 0.2f) * Time.deltaTime; // Izquierda pero menos
                    break;
                case KeyCode.H:
                    transform.position += Vector3.right * (velocidad * 0.2f) * Time.deltaTime; // Derecha pero menos
                    break;
                case KeyCode.J:
                    transform.position += Vector3.right * (velocidad * 0.4f) * Time.deltaTime; // Derecha
                    break;
            }

       

        }

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
            if (slider3 != null)
            {
                slider3.value += 1;

                // Verificar si slider3 ha alcanzado o excedido su valor máximo
                if (slider3.value >= slider3.maxValue)
                {
                    slider3.value = 0; // Reiniciar el valor de slider3 a 0
                    slider1.value -= 5; // Bajar slider1 por 5 unidades
                }
            }
            Destroy(gameObject);
        }
    }
}
