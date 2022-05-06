using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HistoryController : MonoBehaviour
{
    
    public CatInHistory cat;
    public GameObject window;
    private bool isFirstSit;

    // Start is called before the first frame update
    void Start()
    {
        isFirstSit = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!cat.IsWalking()){
            showTextos();
        }
    }

    private void showTextos(){
        Debug.Log("ENTRA");
        if (isFirstSit){
            window.SetActive(true);
            isFirstSit = false;
        }
    }

    
}
