using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]GameObject feet;
    [SerializeField] uint numOfExtraJumps;
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
        Debug.Log(Input.GetAxis("Horizontal"));
        Jump();
        Movement();

    }

    void Jump() {
        if (Input.GetAxis("Jump") != 0) {
            if (rb.velocity.y <= 0 && GetComponent<Rigidbody2D>().velocity.y >= -0.005) {
                rb.velocity = new Vector2(rb.velocity.x, 10f);
                currExtraJumps = numOfExtraJumps;
            } else if (currExtraJumps > 0 && !hasJumped) {
                rb.velocity = new Vector2(rb.velocity.x, 10f);
                    currExtraJumps--;
            }
            hasJumped = true;
        }
        if (Input.GetAxis("Jump") == 0)
            hasJumped = false;
    }

    void Movement() {
        rb.velocity = new Vector2(5 * Input.GetAxis("Horizontal"), rb.velocity.y);
    }
}
