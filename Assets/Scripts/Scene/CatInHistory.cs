using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInHistory : MonoBehaviour
{
    Animator anim;
    new Rigidbody2D rigidbody;
    public float speed;
    float catPosition;
    float finalPosition;
    private bool walking;
    public new Camera camera;
    float cameraWidth;
    float cameraHeight;
    public float catWidth;

    // Start is called before the first frame update
    void Start()
    {
        cameraHeight = 2f * camera.orthographicSize;
        cameraWidth = cameraHeight * camera.aspect;

        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        anim.SetBool("isWalking", true);
        walking = true;
        catPosition = camera.transform.position.x - cameraWidth/2f - catWidth/2f*transform.localScale.x;

        finalPosition = camera.transform.position.x + cameraWidth/2f - 10f;
    }

    void Update()
    {
        if(transform.position.x > finalPosition)
        {
            walking = false;
            anim.SetBool("isWalking", false);
            anim.SetBool("isSitting", true);
        }

        transform.position = new Vector3(catPosition, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(walking)
        {
            catPosition = catPosition + speed*Time.deltaTime;
        }
    }

    public bool IsWalking()
    {
        return walking;
    }
}
