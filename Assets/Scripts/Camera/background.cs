using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class background : MonoBehaviour
{
    public GameObject backgroundPrefab;
    public float backgroundWidth;
    public float backgroundHeight;
    public new Camera camera;
    float cameraWidth;
    float cameraHeight;

    LinkedList<GameObject> backgroundObjects;

    // Start is called before the first frame update
    void Start()
    {
        cameraHeight = 2f * camera.orthographicSize;
        cameraWidth = cameraHeight * camera.aspect;

        backgroundObjects = new LinkedList<GameObject>();
        backgroundObjects.AddFirst(
            Instantiate(
                backgroundPrefab,
                new Vector3 (0, backgroundPrefab.transform.position.y, backgroundPrefab.transform.position.z),
                Quaternion.identity
            )
        );
        while(camera.transform.position.x - cameraWidth/2.0 <= backgroundObjects.First().transform.position.x - backgroundWidth/2f)
        {
            backgroundObjects.AddFirst(
                Instantiate(
                    backgroundPrefab,
                    new Vector3 (backgroundObjects.First().transform.position.x - backgroundWidth, backgroundPrefab.transform.position.y, backgroundPrefab.transform.position.z),
                    Quaternion.identity
                )
            );
        }
        while(camera.transform.position.x + cameraWidth/2.0 >= backgroundObjects.Last().transform.position.x + backgroundWidth/2f)
        {
            backgroundObjects.AddLast(
                Instantiate(
                    backgroundPrefab,
                    new Vector3 (backgroundObjects.Last().transform.position.x + backgroundWidth, backgroundPrefab.transform.position.y, backgroundPrefab.transform.position.z),
                    Quaternion.identity
                )
            );
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(camera.transform.position.x + cameraWidth/2.0 >= backgroundObjects.Last().transform.position.x + backgroundWidth/2f)
        {
            backgroundObjects.AddLast(
                Instantiate(
                    backgroundPrefab,
                    new Vector3(backgroundObjects.Last().transform.position.x + backgroundWidth, backgroundPrefab.transform.position.y, backgroundPrefab.transform.position.z),
                    Quaternion.identity
                )
            );
        }
        if(camera.transform.position.x - cameraWidth/2.0 >= backgroundObjects.First().transform.position.x + backgroundWidth/2f)
        {
            Destroy(backgroundObjects.First());
            backgroundObjects.RemoveFirst();
        }
    }
}
