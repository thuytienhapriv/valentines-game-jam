using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool continueGame;
    public string currentClient;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        continueGame = false;
    }

    private void Start()
    {
        ClientManager.instance.clientIsCatDog(); // choose first client
        Debug.Log("client " + currentClient);
    }

    public void NextClient()
    {
        if (currentClient == "catDog")
        {
            ClientManager.instance.clientIsFlamingos(); // 2nd clients are flamingos
            currentClient = "flamingos";
        } else if (currentClient == "flamingos")
        {
            ClientManager.instance.clientIsRabbitWolf(); // 3rd clients are flamingos
            currentClient = "rabbitWolf";
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
