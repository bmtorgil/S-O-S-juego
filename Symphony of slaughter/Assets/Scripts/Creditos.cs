using UnityEngine;
using UnityEngine.UI;

public class Creditos : MonoBehaviour
{
    public GameObject menuInicial;
    public GameObject panelCreditos;

    public void MostrarPanelCreditos()
    {
        menuInicial.SetActive(false);
        panelCreditos.SetActive(true);
    }

        public void VolverAMenuInicial()
    {
        menuInicial.SetActive(true);
        panelCreditos.SetActive(false);
    }
}