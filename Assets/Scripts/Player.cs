using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] uint numOfExtraJumps;
    [SerializeField] float jumpHeight;
    [SerializeField] float movementSpeed;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer rendrr;
    uint currExtraJumps;
    bool hasJumped;
    Vector2 movement;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        currExtraJumps = numOfExtraJumps;
        hasJumped = false;
        movement = new Vector2(0, 0);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        Jump();
        Movement();

    }

    void Jump() {
        if (Input.GetAxis("Jump") != 0) {
            if (rb.velocity.y <= 0.005 && rb.velocity.y >= -0.005) {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                currExtraJumps = numOfExtraJumps;
                StartCoroutine(CameraShake.Instance.ShakeCamera(1f, 0.3f));  //Showing the syntax for camera shake for JUICING the game
            } 
            else if (currExtraJumps > 0 && !hasJumped) 
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                currExtraJumps--;
            }
            hasJumped = true;
        }
        if (Input.GetAxis("Jump") == 0)
            hasJumped = false;
    }

    void Movement() {
        float xDir = Input.GetAxis("Horizontal");
        Debug.Log(new Vector2(movementSpeed * xDir, rb.velocity.y));
        rb.velocity = new Vector2(movementSpeed * xDir, rb.velocity.y);
        if (rb.velocity.y <= 0.005 && rb.velocity.y >= -0.005) {
            if (xDir < 0) {
                anim.SetBool("isRunning", true);
                rendrr.flipX = true;
            } else if (xDir > 0) {
                anim.SetBool("isRunning", true);
                rendrr.flipX = false;
            } else {
                anim.SetBool("isRunning", false);
            }
        }
        else {
            anim.SetBool("isRunning", false);
            if (xDir < 0) {
                rendrr.flipX = true;
            } else if (xDir > 0) {
                rendrr.flipX = false;
            }
        }
    }
}
