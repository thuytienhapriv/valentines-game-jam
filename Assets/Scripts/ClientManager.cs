using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    public static ClientManager instance;

    public enum animal {catDog, flamingos, rabbitWolf } public animal Clients;
    public enum potion { romantic, platonic, parental } public potion Recipe;
    
    public GameObject[] potionIngredient = new GameObject[3];

    private void Awake()
    {
        if (instance == null) { instance = this; }
        GameManager.instance.currentClient = "catDog";
    }

    void Update()
    {
        switch (Recipe)
        {
            case potion.romantic:
                potionIngredient[0] = IngredientList.instance.ingredient["ing1"];
                potionIngredient[1] = IngredientList.instance.ingredient["ing2"];
                potionIngredient[2] = IngredientList.instance.ingredient["ing3"];
                break;
            case potion.platonic:
                potionIngredient[0] = IngredientList.instance.ingredient["ing4"];
                potionIngredient[1] = IngredientList.instance.ingredient["ing5"];
                potionIngredient[2] = IngredientList.instance.ingredient["ing6"];
                break;
            case potion.parental:
                potionIngredient[0] = IngredientList.instance.ingredient["ing7"];
                potionIngredient[1] = IngredientList.instance.ingredient["ing8"];
                potionIngredient[2] = IngredientList.instance.ingredient["ing9"];
                break;
        }

        switch (Clients)
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

    public void clientIsCatDog()
    {
        Clients = animal.catDog;
        Recipe = potion.platonic;

    }

    public void clientIsFlamingos()
    {
        Clients = animal.flamingos;
        Recipe = potion.romantic;

    }

    public void clientIsRabbitWolf()
    {
        Clients = animal.rabbitWolf;
        Recipe = potion.parental;

    }

    
}
