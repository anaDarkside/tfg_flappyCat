using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    
    public Text puntuationText;
    
    void Start()
    {
        string puntuationString = (UtilsStatic.puntuationFinal).ToString();
        string texto = "La puntuación final ha sido de " + puntuationString + " puntos.";
        puntuationText.text = texto;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
