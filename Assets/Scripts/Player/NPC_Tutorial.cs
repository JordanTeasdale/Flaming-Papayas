using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class NPC_Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    private Dialog dialogue;
    private bool canTalk = true;
    [SerializeField] private Animator anim;
    //[SerializeField] private string sceneToLoad;  If we want to load another level when transition ends.

    void Start()
    {
        dialogue = GetComponent<Dialog>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //IEnumerator FadeOut()
    //{
    //    anim.SetTrigger("Fade");
    //    yield return new WaitForSeconds(3);
    //    SceneManager.LoadScene(sceneToLoad);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canTalk && PlayerPrefs.GetInt("CanTalkPref") == 0)
        {
            canTalk = false;
            PlayerPrefs.SetInt("CanTalkPref", 1);
            PlayerPrefs.Save();
            dialogue.StartDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !canTalk)
        {
            //StartCoroutine(FadeOut());  If changing the scene 
            //Do something when exiting the chat after chat has ended
        }
    }
}
