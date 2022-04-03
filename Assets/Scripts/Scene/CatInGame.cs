using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInGame : MonoBehaviour
{
    Animator anim;
    new Rigidbody2D rigidbody;
    public new CameraMovement camera;
    public float jumpAmount;
    private float positionInCamera;
    private bool preparingJump;
    private bool jumping;
    private bool falling;
    private float startJump;

    public float secondsPrepareJump;

    // Start is called before the first frame update
    void Start()
    {
          anim = GetComponent<Animator>();
          rigidbody = GetComponent<Rigidbody2D>();
          anim.SetBool("isWalking", true);
          anim.SetBool ("isJumping", false);
          anim.SetBool("isSitting", false);

          preparingJump = false;
          jumping = false;
          falling = false;

          positionInCamera = transform.position.x-camera.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !preparingJump && !jumping && !falling){
            preparingJump = true;
            startJump = Time.time;
            anim.SetBool("isJumping", true);
            anim.SetBool("isWalking", false);
        }

        if(jumping && rigidbody.velocity.y < 0)
        {
            jumping = false;
            falling = true;
        }

        if(falling && rigidbody.velocity.y == 0)
        {
            falling = false;
            anim.SetBool("isJumping", false);
            anim.SetBool("isWalking", true);
        }
        
        transform.position = new Vector3(positionInCamera + camera.transform.position.x, transform.position.y, transform.position.z);
    }

    void FixedUpdate()
    {
        if(preparingJump && (Time.time - startJump) > secondsPrepareJump)
        {
            rigidbody.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            preparingJump = false;
            jumping = true;
        }
    }
}
