using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] uint numOfExtraJumps;
    [SerializeField] float jumpHeight;
    [SerializeField] float movementSpeed;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer rendrr;
    [SerializeField] GameObject deathMenu;
    [SerializeField] GameObject feet;
    uint currExtraJumps;
    bool hasJumped;
    Vector2 movement;
    Rigidbody2D rb;

    public bool isOnGround = false;
    public bool canMove = true;
    public bool hasKey = false;

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
        if(canMove)
        {
            Jump();
            Movement();
        }
        else
        {
            rb.velocity = new Vector2(0 , rb.velocity.y); //Stop player
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
            anim.SetBool("isRunning", false);
        }

    }

    void Jump() {
        if (Input.GetAxis("Jump") != 0) {
            if (isOnGround) {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                currExtraJumps = numOfExtraJumps;
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
        if (rb.velocity.y >= 0.005)
            anim.SetBool("isJumping", true);
        else
            anim.SetBool("isJumping", false);
        if (rb.velocity.y <= -0.005)
            anim.SetBool("isFalling", true);
        else
            anim.SetBool("isFalling", false);
    }

    public void TakeDamage(int damage) {
        canMove = false;
        anim.SetBool("isJumping", false);
        anim.SetBool("isFalling", false);
        anim.SetBool("isRunning", false);
        anim.SetBool("isDead", true);

        StartCoroutine(CameraShake.Instance.ShakeCamera(1f, 0.3f));  //Showing the syntax for camera shake for JUICING the game
        StartCoroutine(ShowDeathMenu());
    }

    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    IEnumerator ShowDeathMenu()
    {
        yield return new WaitForSeconds(2);
        deathMenu.SetActive(true);
    }

}
