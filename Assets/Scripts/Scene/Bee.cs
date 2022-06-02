using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bee : MonoBehaviour
{
    
    public float speed;
    float beePosition;

    // Start is called before the first frame update
    void Start()
    {
        beePosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position = new Vector3(beePosition, transform.position.y, transform.position.z); 
    }

    void FixedUpdate()
    {
        beePosition = beePosition + speed*Time.deltaTime;
    }

    
}
