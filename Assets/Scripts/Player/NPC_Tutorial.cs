using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will be engaged into the god who will talk with the user to give the tutorial.
public class NPC_Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    private Dialog dialogue;
    private bool canTalk = true;
    [SerializeField] private Animator anim;
    [SerializeField] private string sceneToLoad;

    void Start()
    {
        dialogue = GetComponent<Dialog>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canTalk)
        {
            canTalk = false;
            dialogue.StartDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !canTalk)
        {
            //Do something when existing the talking area if you want 
        }
    }
}
