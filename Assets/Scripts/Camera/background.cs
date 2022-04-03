using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public GameObject background1;
    public GameObject background2;
    public GameObject background3;
    public new GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(camera.transform.position.x > background3.transform.position.x)
        {
            GameObject aux = background1;
            background1 = background2;
            background2 = background3;
            background3 = aux;
            background3.transform.position = new Vector3(background2.transform.position.x+21, background2.transform.position.y, background2.transform.position.z);
        }
    }
}
