using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FueraLinea : MonoBehaviour
{
    public Slider slider2; // Referencia al slider

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "flecha")
        {
            // Si hay un slider asignado, disminuir su valor
            if (slider2 != null)
            {
                slider2.value -= 1; // Decrementar el valor del slider
            }

            // Destruir la flecha
            Destroy(collision.gameObject);
        }
    }
}