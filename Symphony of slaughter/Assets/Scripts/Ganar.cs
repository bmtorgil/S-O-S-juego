using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ganar : MonoBehaviour
{
    public GameObject objectToShake; // El GameObject que se sacudirá
    public GameObject firstCanvas; // El primer Canvas que aparecerá
    public GameObject secondCanvas; // El segundo Canvas que aparecerá
    public GameObject spriteObject; // El objeto del Sprite que aparecerá

    private bool isShaking = false;
    private bool firstClickDone = false;
    private bool secondClickDone = false;
    private Vector3 originalPosition;

    void Start()
    {
        if (objectToShake != null)
        {
            originalPosition = objectToShake.transform.localPosition;
            StartCoroutine(ShakeObject(2.0f)); // Sacude el objeto durante 2 segundos
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick();
        }
    }

    private IEnumerator ShakeObject(float duration)
    {
        isShaking = true;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * 0.1f;
            float y = Random.Range(-1f, 1f) * 0.1f;
            objectToShake.transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        objectToShake.transform.localPosition = originalPosition;
        isShaking = false;

        // Mostrar el primer Canvas después de que el sacudido haya terminado
        if (firstCanvas != null)
        {
            firstCanvas.SetActive(true);
        }
    }

    private void HandleClick()
    {
        if (firstClickDone && !secondClickDone && secondCanvas != null)
        {
            secondCanvas.SetActive(true);
            secondClickDone = true;
        }
        else if (!firstClickDone && firstCanvas != null)
        {
            firstCanvas.SetActive(true);
            firstClickDone = true;
        }
        else if (firstClickDone && secondClickDone && spriteObject != null)
        {
            spriteObject.SetActive(true);
        }
    }
}
