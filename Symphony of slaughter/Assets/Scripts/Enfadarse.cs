using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Necesario para IEnumerator

public class GameObjectChanger : MonoBehaviour
{
    public Slider slider; // Asigna el Slider en el Inspector

    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;

    private bool gameObject3Played = false;

    void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        ActivateGameObject(gameObject1); // Inicialmente activar gameObject1
    }

    void OnSliderValueChanged(float value)
    {
        float percentage = value / slider.maxValue;

        if (percentage <= 0.5f && percentage > 0.4f)
        {
            ActivateGameObject(gameObject2);
        }
        else if (percentage <= 0.4f && percentage > 0.25f)
        {
            if (!gameObject3Played)
            {
                ActivateGameObject(gameObject3);
                StartCoroutine(PlayGameObject3Once());
            }
        }
        else if (percentage <= 0.25f)
        {
            if (gameObject3Played)
            {
                ActivateGameObject(gameObject4);
            }
        }
        else
        {
            ActivateGameObject(gameObject1);
        }
    }

    IEnumerator PlayGameObject3Once()
    {
        gameObject3Played = true;
        // Asume que gameObject3 tiene una animación que dura 1 segundo
        yield return new WaitForSeconds(1.2f); // Espera a que la animación se reproduzca una vez
        ActivateGameObject(gameObject4); // Cambia a gameObject4 después de que gameObject3 se reproduce una vez
    }

    void ActivateGameObject(GameObject go)
    {
        gameObject1.SetActive(go == gameObject1);
        gameObject2.SetActive(go == gameObject2);
        gameObject3.SetActive(go == gameObject3);
        gameObject4.SetActive(go == gameObject4);
    }
}
