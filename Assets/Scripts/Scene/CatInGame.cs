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

    // Start is called before the first frame update
    void Start()
    {
          anim = GetComponent<Animator>();
          rigidbody = GetComponent<Rigidbody2D>();
          anim.SetBool("isWalking", true);
          anim.SetBool ("isJumping", false);

          positionInCamera = transform.position.x-camera.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)){
            rigidbody.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        
        transform.position = new Vector3(positionInCamera + camera.transform.position.x, transform.position.y, transform.position.z);
    }
}
