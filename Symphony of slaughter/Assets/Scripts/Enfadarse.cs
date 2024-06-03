using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enfadarse : MonoBehaviour
{
    public Slider slider;
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;
    public GameObject gameObject5;

    private bool gameObject4Played = false;

    void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        SetGameObjectActive(gameObject1);
    }

    void OnSliderValueChanged(float value)
    {
        float percentage = value / slider.maxValue;

        // Cambiar el gameobject dependiendo del porcentaje
        if (percentage >= 0.5f)
        {
            SetGameObjectActive(gameObject2);
        }

        if (percentage >= 0.6f)
        {
            SetGameObjectActive(gameObject3);
        }

        if (percentage >= 0.75f && !gameObject4Played)
        {
            SetGameObjectActive(gameObject4);
            gameObject4Played = true;
            // Reproducir sonido o animación de gameObject4 aquí
            Invoke("ChangeToGameObject5", 1.0f); // Cambiar a gameObject5 después de 1 segundo
        }
    }

    void ChangeToGameObject5()
    {
        SetGameObjectActive(gameObject5);
    }

    void SetGameObjectActive(GameObject go)
    {
        gameObject1.SetActive(go == gameObject1);
        gameObject2.SetActive(go == gameObject2);
        gameObject3.SetActive(go == gameObject3);
        gameObject4.SetActive(go == gameObject4);
        gameObject5.SetActive(go == gameObject5);
    }
}
