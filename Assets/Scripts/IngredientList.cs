using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public bool nowMakePotion;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        
        mouseHoversCauldron = false;
        inPotion = new GameObject[3];
        nowMakePotion = false;
        
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

    public bool CheckPotion()
    {
        GameObject[] checkList = ClientManager.instance.potionIngredient;

        bool isGood = true;/*
        Debug.Log("Checking " + ClientManager.instance.potionIngredient[0] + " " + ClientManager.instance.potionIngredient[1] + " " + ClientManager.instance.potionIngredient[2]);
        Debug.Log("Compare with " + inPotion[0] + " " + inPotion[1] + " " + inPotion[2]);
        Debug.Log(i + " " + inPotion[i] + " " + ClientManager.instance.potionIngredient.Contains(inPotion[i]));*/

        for (int i = 0; i < checkList.Length; i++)
        {
            bool ingExistsinList = true;

            for (int j = 0; j < inPotion.Length; j++)
            {
                ingExistsinList = true;

                if (inPotion[j] != checkList[i])
                {
                    ingExistsinList = false;
                } else
                {
                    checkList[i] = null;
                    break;
                }

                
            }

            if (ingExistsinList == false)
            {
                Debug.Log("potion is BAD");

                isGood = false; return isGood;
            }
        }
        Debug.Log("potion is GOOD");
        return isGood;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
