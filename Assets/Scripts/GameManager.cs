using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool continueGame;
    public string currentClient;
    public bool dialogueNow;
    public bool countNow;
    public bool countLoseNow;
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private GameObject timerGO;

    private float time = 0f;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        continueGame = false;
        dialogueNow = false;
        countNow = false;
        countLoseNow = false;
        FindAnyObjectByType<PlayerBehaviour>().Idle();
    }

    private void Start()
    {
        // talking to catndog
        ClientManager.instance.clientIsCatDog(); // choose first client
        dialogueNow = true;
        dialogueCanvas.SetActive(true);

        Debug.Log("client " + currentClient);
    }

    private void Update()
    {
        if (dialogueNow == true)
        {
            Time.timeScale = 0f;
            
            
        } else
        {
            Time.timeScale = 1f;
            dialogueCanvas.SetActive(false);
            //FindAnyObjectByType<PlayerBehaviour>().Idle();
        }

        if (countNow == true)
        {
            if (FindAnyObjectByType<PlayerBehaviour>().animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f)
            {
                dialogueNow = true;
                dialogueCanvas.SetActive(true);
                countNow = false;
                FindAnyObjectByType<PlayerBehaviour>().Idle();
                /*if (FindAnyObjectByType<PlayerBehaviour>().animator.GetCurrentAnimatorStateInfo(0).IsName("frog_stir_plat") || FindAnyObjectByType<PlayerBehaviour>().animator.GetCurrentAnimatorStateInfo(0).IsName("frog_stir_love"))
                {
                    
                }*/
            }
        }

        if (countLoseNow == true)
        {
            if (FindAnyObjectByType<PlayerBehaviour>().animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f)
            {
                if (FindAnyObjectByType<PlayerBehaviour>().animator.GetCurrentAnimatorStateInfo(0).IsName("frog_stir_plat_fail") || FindAnyObjectByType<PlayerBehaviour>().animator.GetCurrentAnimatorStateInfo(0).IsName("frog_stir_love_fail") || FindAnyObjectByType<PlayerBehaviour>().animator.GetCurrentAnimatorStateInfo(0).IsName("frog_stir_parent_fail"))
                {
                    countLoseNow = false;
                    SceneManager.LoadScene(1);
                }
            }
        }

    }

    public void NextClient()
    {
        if (currentClient == "catDog")
        {
            ClientManager.instance.clientIsFlamingos(); // 2nd clients are flamingos
            currentClient = "flamingos";

            FindAnyObjectByType<PlayerBehaviour>().PlatWin();
            countNow = true;
        } else if (currentClient == "flamingos")
        {
            ClientManager.instance.clientIsRabbitWolf(); // 3rd clients are flamingos
            currentClient = "rabbitWolf";

            FindAnyObjectByType<PlayerBehaviour>().LoveWin();
            countNow = true;

            /*dialogueNow = true;
            dialogueCanvas.SetActive(true);*/
        } else if (currentClient == "rabbitWolf")
        {
            Win();
        }
        //Debug.Log("client " + currentClient);

    }

    public void Lose()
    {
        if (currentClient == "catDog")
        {
            FindAnyObjectByType<PlayerBehaviour>().LoveLose();
            countLoseNow = true;
        } else if (currentClient == "flamingos")
        {
            FindAnyObjectByType<PlayerBehaviour>().PlatLose();
            countLoseNow = true;
        } else if (currentClient == "rabbitWolf")
        {
            FindAnyObjectByType<PlayerBehaviour>().ParentLose();
            countLoseNow = true;
        }


        
        Debug.Log("you lost vagshjdjiokfjbjk bjnlkjnbjk kn");
    }

    public void Win()
    {

    }

/*
    IEnumerator PlayAnim(string anim)
    {
        if (anim == "LoveWin") { FindAnyObjectByType<PlayerBehaviour>().LoveWin(); }
        if (anim == "LoveLose") { FindAnyObjectByType<PlayerBehaviour>().LoveLose(); }
        if (anim == "PlatWin") { FindAnyObjectByType<PlayerBehaviour>().PlatWin(); }
        if (anim == "PlatLose") { FindAnyObjectByType<PlayerBehaviour>().PlatLose(); }

        yield return null;
    }*/

}
