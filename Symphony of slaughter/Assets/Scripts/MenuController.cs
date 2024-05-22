using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject menuInicial;
    public GameObject panelOpciones;

    public void MostrarPanelOpciones()
    {
        menuInicial.SetActive(false);
        panelOpciones.SetActive(true);
    }

        public void VolverAMenuInicial()
    {
        menuInicial.SetActive(true);
        panelOpciones.SetActive(false);
    }
}