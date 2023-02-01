using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]GameObject feet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetComponent<Rigidbody2D>().velocity.y);
        Jump();
    }

    void Jump() {
        if (GetComponent<Rigidbody2D>().velocity.y <= 0 && GetComponent<Rigidbody2D>().velocity.y >= -0.005) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 10f * Input.GetAxis("Jump"), 0);
        }
    }
}
