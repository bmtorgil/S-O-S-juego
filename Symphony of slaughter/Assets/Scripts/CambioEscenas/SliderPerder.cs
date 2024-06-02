using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderPerder : MonoBehaviour
{
    public Slider slider;
    public string sceneName;

    private bool sceneLoaded = false;

    void Update()
    {
        if (slider.value <= 0 && !sceneLoaded)
        {
            sceneLoaded = true;
            LoadScene();
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
