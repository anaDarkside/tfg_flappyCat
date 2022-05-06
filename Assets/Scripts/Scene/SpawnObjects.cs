using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SpawnObjects : MonoBehaviour
{
    public GameObject vespa;
    public GameObject lemon;
    public GameObject worm;
    public GameObject toyMouse;
    public GameObject feed;
    public GameObject foodTin;
    public float maxX;
    public float minX;
    private float lastX;
    private bool previousBonus;
    private LinkedList<GameObject> objects;
    public new Camera camera;
    float cameraWidth;
    float cameraHeight;


    void Start()
    {
        cameraHeight = 2f * camera.orthographicSize;
        cameraWidth = cameraHeight * camera.aspect;
        objects = new LinkedList<GameObject>();

        previousBonus = true;
        lastX = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(objects.Count == 0 || objects.Last().transform.position.x <= camera.transform.position.x + cameraWidth/2.0 )
        {
            spawnObject();            
        }
        if(objects.Count > 0 && objects.First().transform.position.x <= camera.transform.position.x - cameraWidth)
        {
            Destroy(objects.First());
            objects.RemoveFirst();
        }
    }

    void FixedUpdate()
    {
        
    }

    void spawnObject()
    {
        float random = Random.Range(minX, maxX);
        float objectX = lastX + random;

        if (previousBonus)
        {
            objects.AddLast(InstantiateBadObject(objectX));
        }
        else
        {
            int randomNumber = Random.Range(1,3);
            if(randomNumber == 1)
            {
                objects.AddLast(InstantiateBonusObject(objectX));
            }
            else
            {
                objects.AddLast(InstantiateBadObject(objectX));
            }
        }
        lastX = objectX;
    }

    GameObject InstantiateBonusObject(float objectX)
    {
        previousBonus = true;
        int randomNumber = Random.Range(1,4);
        if (randomNumber == 1)
        {
            return Instantiate(toyMouse, new Vector3(objectX, -11f), toyMouse.transform.rotation);
        }
        else if (randomNumber == 2)
        {
            return Instantiate(foodTin, new Vector3(objectX, -11f), foodTin.transform.rotation);
        }
        else
        {
            return Instantiate(feed, new Vector3(objectX, -12f), feed.transform.rotation);
        }
    }

    GameObject InstantiateBadObject(float objectX)
    {
        previousBonus = false;
        int randomNumber = Random.Range(1,4);
        if (randomNumber == 1)
        {
            return Instantiate(worm, new Vector3(objectX, -11f), worm.transform.rotation);
        }
        else if (randomNumber == 2)
        {        
            return Instantiate(lemon, new Vector3(objectX, -11f), lemon.transform.rotation);
        }
        else
        {
            float randomY = Random.Range(-4,3);
            return Instantiate(vespa, new Vector3(objectX, randomY), vespa.transform.rotation);            
        }
    }
}
