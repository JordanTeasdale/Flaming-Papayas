using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]GameObject feet;
    [SerializeField] uint numOfExtraJumps;
    uint currExtraJumps;
    bool hasJumped;

    // Start is called before the first frame update
    void Start()
    {
        currExtraJumps = numOfExtraJumps;
        hasJumped = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currExtraJumps);
        Jump();
    }

    void Jump() {
        if (Input.GetAxis("Jump") != 0) {
            if (GetComponent<Rigidbody2D>().velocity.y <= 0 && GetComponent<Rigidbody2D>().velocity.y >= -0.005) {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10f, 0);
                currExtraJumps = numOfExtraJumps;
            } else if (currExtraJumps > 0 && !hasJumped) {
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10f, 0);
                    currExtraJumps--;
            }
            hasJumped = true;
        }
        if (Input.GetAxis("Jump") == 0)
            hasJumped = false;

    }
}
