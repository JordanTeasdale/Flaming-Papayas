using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    // This script will go on an empty game object called dialog manager. And fill the text spaces
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private string[] sentences;
    private int index = 0;
    [SerializeField] private float typeSpeed = 0.00002f;

    [SerializeField] private GameObject continueButton;
    [SerializeField] private Animator talkerAnim;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Player playerScript;



    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }

    public void StartDialogue()
    {
        playerScript.canMove = false;
        canvas.SetActive(true);
        textDisplay.text = "";
        StartCoroutine(Type());
    }
    public IEnumerator Type()
    {

        canvas.SetActive(true);
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    public void ContinueDialogue()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            if (talkerAnim)
                talkerAnim.SetBool("IsTalking", true);
        }
        else
        {
            textDisplay.text = "";
            if (talkerAnim)
                talkerAnim.SetBool("IsTalking", true);
            canvas.SetActive(false);
            playerScript.canMove = true;

        }
    }
}
