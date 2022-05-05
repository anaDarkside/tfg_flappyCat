using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInMainMenu : MonoBehaviour
{
    float catPosition;
    public new Camera camera;
    float cameraWidth;
    float cameraHeight;



    public float catWidth;




    // Start is called before the first frame update
    void Start()
    {
        cameraHeight = 2f * camera.orthographicSize;
        cameraWidth = cameraHeight * camera.aspect;

        catPosition = camera.transform.position.x - cameraWidth/4f /*+ catWidth/2f*transform.localScale.x*/;
        transform.position = new Vector3(catPosition, transform.position.y, transform.position.z);
    }

}
