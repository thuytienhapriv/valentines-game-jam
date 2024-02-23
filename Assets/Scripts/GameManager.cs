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
    //public bool countNow;
    //public bool countLoseNow;

    AnimatorClipInfo[] m_CurrentClipInfo;
    string m_ClipName;

    [SerializeField] private GameObject dialogueCanvas;
    //[SerializeField] private GameObject timerGO;

    //[SerializeField] private GameObject frogMC;
    [SerializeField] private GameObject catnDog;
    [SerializeField] private GameObject flamingos;
    [SerializeField] private GameObject rabbitWolf;
    [SerializeField] private GameObject hearts1;
    [SerializeField] private GameObject hearts2;
    [SerializeField] private GameObject hearts3;

    //private float time = 0f;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        continueGame = false;
        dialogueNow = false;
    }

    private void Start()
    {
        // talking to catndog
        ClientManager.instance.clientIsCatDog(); // choose first client
        dialogueNow = true;
        dialogueCanvas.SetActive(true);
        hearts1.SetActive(false);
        hearts2.SetActive(false);
        hearts3.SetActive(false);
        FindAnyObjectByType<PlayerBehaviour>().Idle();

        Debug.Log("client " + currentClient);
    }

    private void Update()
    {
        if (dialogueNow == true)
        {
            Time.timeScale = 0f;
            dialogueCanvas.SetActive(true);
        } 
        else
        {
            // PlayTime
            Time.timeScale = 1f;
            dialogueCanvas.SetActive(false);
        }

        m_CurrentClipInfo = FindAnyObjectByType<PlayerBehaviour>().animator.GetCurrentAnimatorClipInfo(0);
        //Debug.Log(m_CurrentClipInfo[0].clip.name + " " + FindAnyObjectByType<PlayerBehaviour>().animator.GetCurrentAnimatorStateInfo(0).normalizedTime);

  
        // if finished stirring plat win
        if (m_CurrentClipInfo[0].clip.name == "frog_stir_plat" && (FindAnyObjectByType<PlayerBehaviour>().animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)){
            hearts1.SetActive(true);
            hearts1.GetComponent<Animator>().enabled = true;
            dialogueNow = true;
            FindAnyObjectByType<PlayerBehaviour>().Idle();
        }

        // if finished stirring love win
        if (m_CurrentClipInfo[0].clip.name == "frog_stir_love" && (FindAnyObjectByType<PlayerBehaviour>().animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1))
        {
            Debug.Log("play now");
            hearts2.SetActive(true);
            hearts2.GetComponent<Animator>().enabled = true;
            dialogueNow = true;
            FindAnyObjectByType<PlayerBehaviour>().Idle();
        }

        // if finished stirring parent win
        if (m_CurrentClipInfo[0].clip.name == "frog_stir_parent" && (FindAnyObjectByType<PlayerBehaviour>().animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1))
        {
            Debug.Log("play now");
            hearts3.SetActive(true);
            hearts3.GetComponent<Animator>().enabled = true;
            dialogueNow = true;
            FindAnyObjectByType<PlayerBehaviour>().Idle();
        }

        // if finished stirring plat lose
        if (m_CurrentClipInfo[0].clip.name == "frog_stir_plat_fail" && (FindAnyObjectByType<PlayerBehaviour>().animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1))
        {
            catnDog.GetComponent<Animator>().enabled = true;
        }

        // if finished stirring love lose
        if (m_CurrentClipInfo[0].clip.name == "frog_stir_love_fail" && (FindAnyObjectByType<PlayerBehaviour>().animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1))
        {
            flamingos.GetComponent<Animator>().enabled = true;
        }
        // if finished sitrring parent lose

        if (m_CurrentClipInfo[0].clip.name == "frog_stir_parent_fail" && (FindAnyObjectByType<PlayerBehaviour>().animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1))
        {
            rabbitWolf.GetComponent<Animator>().enabled = true;
        }


        if (catnDog.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >=1 || flamingos.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 || rabbitWolf.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            LoadLoseScreen();
        }


    }

    public void NextClient()
    {
        if (currentClient == "catDog")
        {
            ClientManager.instance.clientIsFlamingos(); // 2nd clients are flamingos
            currentClient = "flamingos";
            FindAnyObjectByType<PlayerBehaviour>().PlatWin();
            
        } else if (currentClient == "flamingos")
        {
            ClientManager.instance.clientIsRabbitWolf(); // 3rd clients are flamingos
            currentClient = "rabbitWolf";
            FindAnyObjectByType<PlayerBehaviour>().LoveWin();
        } else if (currentClient == "rabbitWolf")
        {
            Win();
        }
    }

    public void Lose()
    {
        if (currentClient == "catDog")
        {
            FindAnyObjectByType<PlayerBehaviour>().PlatLose();
        } else if (currentClient == "flamingos")
        {
            FindAnyObjectByType<PlayerBehaviour>().LoveLose();
        } else if (currentClient == "rabbitWolf")
        {
            FindAnyObjectByType<PlayerBehaviour>().ParentLose();
        }
    }

    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    public void Win()
    {
        Debug.Log("Congrats");
        SceneManager.LoadScene("Menu");

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
