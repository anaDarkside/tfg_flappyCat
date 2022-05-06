
using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {
                    
    public GUIStyle customButton;
    
    void OnGUI () {
        // Make a button. We pass in the GUIStyle defined above as the style to use
        GUI.Button (new Rect (10,10,150,20), "I am a Custom Button", customButton);
    }
    
}