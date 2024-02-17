using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    public static ClientManager instance;

    public enum animal {catDog, flamingos, rabbitWolf } public animal clients;
    public enum potion { romantic, platonic, parental } public potion Recipe;
    
    public GameObject[] ingredient = new GameObject[3];

    private void Awake()
    {
        if (instance == null) { instance = this; }
    }

    void Start()
    {
        switch (Recipe)
        {
            case potion.romantic:
                ingredient[1] = IngredientList.instance.ingredient["ing1"];
                ingredient[2] = IngredientList.instance.ingredient["ing2"];
                ingredient[0] = IngredientList.instance.ingredient["ing3"];
                break;
            case potion.platonic:
                ingredient[1] = IngredientList.instance.ingredient["ing4"];
                ingredient[2] = IngredientList.instance.ingredient["ing5"];
                ingredient[0] = IngredientList.instance.ingredient["ing6"];
                break;
            case potion.parental:
                ingredient[1] = IngredientList.instance.ingredient["ing7"];
                ingredient[2] = IngredientList.instance.ingredient["ing8"];
                ingredient[0] = IngredientList.instance.ingredient["ing9"];
                break;
        }

        switch (clients)
        {
            case animal.catDog:
                Recipe = potion.platonic;
                break;
            case animal.flamingos:
                Recipe = potion.romantic;
                break;
            case animal.rabbitWolf:
                Recipe = potion.parental;
                break;
        }
    }

    void Update()
    {
        
    }
}
