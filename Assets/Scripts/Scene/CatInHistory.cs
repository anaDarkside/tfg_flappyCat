using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInHistory : MonoBehaviour
{
    Animator anim;
    new Rigidbody2D rigidbody;
    public float speed;
    public float finalPosition;
    private bool walking;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        anim.SetBool("isWalking", true);
        walking = true;
    }

    void Update()
    {
        if(transform.position.x > finalPosition)
        {
            walking = false;
            anim.SetBool("isWalking", false);
            anim.SetBool("isSitting", true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(walking)
        {
            transform.position += Vector3.right*Time.deltaTime*speed;

        }
    }

    public bool IsWalking()
    {
        return walking;
    }
}
