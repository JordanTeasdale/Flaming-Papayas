using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Feet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        gameObject.GetComponentInParent<Player>().isOnGround = true;
        Debug.Log("ground");
    }

    private void OnTriggerExit2D(Collider2D collision) {
        gameObject.GetComponentInParent<Player>().isOnGround = false;
        Debug.Log("air");
    }
}
