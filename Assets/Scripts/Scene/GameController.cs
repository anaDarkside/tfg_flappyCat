using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private const string MainMenu = "MainMenu";
    private const string FlappyCat = "FlappyCat";
    private const string HistoryGame = "HistoryGame";
    // Poner aqui los nombres de las escenas

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadGameScene()
    {
        SceneManager.LoadScene(FlappyCat);
    }

    public void loadHistoryGame(){
        SceneManager.LoadScene(HistoryGame);
    }
}