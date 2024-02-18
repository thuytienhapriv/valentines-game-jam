using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index; // ktory element z string []

    private void Start()
    {
        textComponent.text = string.Empty;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (index == 5 || index == 11 || index == 16)
            {
                GameManager.instance.dialogueNow = false;
                if (index == 5 || index == 11)
                { index++; }
            }
            if (textComponent.text == lines[index])
            {
                //Debug.Log("index" + index);
                NextLine();

            } else
            {
                StopAllCoroutines();
                //NextLine();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
             gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
