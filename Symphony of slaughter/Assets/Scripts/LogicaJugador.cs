using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicaJugador : MonoBehaviour
{
    public int puntuacion = 0;
    public TextMeshProUGUI texto;
    public int contador = 0;
    public bool adentro = false;

    // Start is called before the first frame update
    void Start()
    {

       texto=GameObject.Find("ScoreUI").GetComponent<TextMeshProUGUI>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(contador==2){
            adentro = true;
        }
        else{
            adentro = false;
        }
    }
}
