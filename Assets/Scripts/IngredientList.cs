using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class IngredientList : MonoBehaviour
{
    public static IngredientList instance;
    public GameObject[] ing;
    public Dictionary<string, GameObject> ingredient;
    public bool mouseHoversCauldron;

    public Image[] potionSlot;
    public GameObject[] inPotion;

    private void Awake()
    {
        mouseHoversCauldron = false;
        inPotion = new GameObject[3];

        if (instance == null) { instance = this; }
    
        ingredient = new Dictionary<string, GameObject>()
        {
         {"ing1", ing[0]},
         {"ing2", ing[1]},
         {"ing3", ing[2]},
         {"ing4", ing[3]},
         {"ing5", ing[4]},
         {"ing6", ing[5]},
         {"ing7", ing[6]},
         {"ing8", ing[7]},
         {"ing9", ing[8]},

        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
