using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    // Start is called before the first frame update
    WindowManager windowManager;
    public CatInHistory cat;
    private bool waiting;

    void Start()
    {
        windowManager = GetComponent<WindowManager>();
        waiting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(waiting && !cat.IsWalking())
        {
            waiting = false;
            windowManager.show();
        }
    }
}
