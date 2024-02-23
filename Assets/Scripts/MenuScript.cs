using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public static MenuScript instance;

    private void Awake() { if (instance == null) { instance = this; } }

    public void PlayGame()
    {
        SceneManager.LoadScene(0);
    }
}
