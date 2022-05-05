using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatInGame : MonoBehaviour
{
    public new Camera camera;
    Animator anim;
    new Rigidbody2D rigidbody;
    public int lives;
    public GameObject heartPrefab;
    public RectTransform positionFirstHeart;
    public Canvas myCanvas;
    public int offSet;
    public float jumpAmount;
    private float positionInCamera;
    private bool preparingJump;
    private bool jumping;
    private bool falling;
    private float startJump;

    public float secondsPrepareJump;
    public float speed;
    float catPosition;
    List<GameObject> arrayHearts;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        anim.SetBool("isWalking", true);
        anim.SetBool ("isJumping", false);
        anim.SetBool("isSitting", false);

        catPosition = transform.position.x;
        preparingJump = false;
        jumping = false;
        falling = false;

        positionInCamera = transform.position.x-camera.transform.position.x;

        Transform positionHeart = positionFirstHeart;
        arrayHearts = new List<GameObject>();
        for(int i = 0; i < lives; ++i)
        {
            GameObject newHeart = Instantiate(heartPrefab, positionHeart.position, Quaternion.identity);
            newHeart.transform.SetParent(myCanvas.transform);
            arrayHearts.Add(newHeart);
            positionHeart.position = new Vector2(positionHeart.position.x + offSet , positionHeart.position.y);
        }
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
        
        transform.position = new Vector3(catPosition, transform.position.y, transform.position.z);
        camera.transform.position = new Vector3(catPosition - positionInCamera, camera.transform.position.y, camera.transform.position.z);

        for(int i = 0; i < arrayHearts.Count; ++i)
        {
            if(i < lives)
            {
                arrayHearts[i].SetActive(true);
            }
            else
            {
                arrayHearts[i].SetActive(false);
            }
            
        }
    }

    void FixedUpdate()
    {
        catPosition = catPosition + speed*Time.deltaTime;
        if(preparingJump && (Time.time - startJump) > secondsPrepareJump)
        {
            rigidbody.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            preparingJump = false;
            jumping = true;
        }
    }

    void addLife()
    {
        if (lives < 7)
        {
            ++lives;
        }
    }

    void lostLife()
    {
        --lives;
        if (lives <= 0)
        {
            // call GameOver
        }
    }

    int getNumberOfLives()
    {
        return lives;
    }

}
