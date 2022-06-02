using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public CatInGame cat;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause(){
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        cat.pausePuntuation();
    }

    public void Resume(){
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        cat.startPuntuation();
    }
}
