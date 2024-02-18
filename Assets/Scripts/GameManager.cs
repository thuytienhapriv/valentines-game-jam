using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool continueGame;
    public string currentClient;
    public bool dialogueNow;
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private GameObject timerGO;

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
        }
    }

    public void NextClient()
    {
        if (currentClient == "catDog")
        {
            ClientManager.instance.clientIsFlamingos(); // 2nd clients are flamingos
            currentClient = "flamingos";
            dialogueNow = true;
            dialogueCanvas.SetActive(true) ;

        } else if (currentClient == "flamingos")
        {
            ClientManager.instance.clientIsRabbitWolf(); // 3rd clients are flamingos
            currentClient = "rabbitWolf";
            dialogueNow = true;
            dialogueCanvas.SetActive(true);
        } else if (currentClient == "rabbitWolf")
        {
            Win();
        }
        Debug.Log("client " + currentClient);

    }

    public void Lose()
    {
        Debug.Log("you lost vagshjdjiokfjbjk bjnlkjnbjk kn");
    }

    public void Win()
    {

    }


}
