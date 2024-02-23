using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public void Awake()
    {
        if (instance == null) { instance = this; }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main Scene");
    }
}
