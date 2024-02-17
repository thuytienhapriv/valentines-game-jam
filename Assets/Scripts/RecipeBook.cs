using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBook : MonoBehaviour
{
    public static RecipeBook instance;
    public enum potion { romantic, platonic, parental };
    public potion Recipe;
    public GameObject[] ingredient = new GameObject[3];
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        switch (Recipe)
        {
            case potion.romantic:
                ingredient[0] = IngredientList.instance.ingredient["ing0"];
                ingredient[1] = IngredientList.instance.ingredient["ing1"];
                ingredient[2] = IngredientList.instance.ingredient["ing2"];
                break;
            case potion.platonic:
                ingredient[0] = IngredientList.instance.ingredient["ing3"];
                ingredient[1] = IngredientList.instance.ingredient["ing4"];
                ingredient[2] = IngredientList.instance.ingredient["ing5"];
                break;
            case potion.parental:
                ingredient[0] = IngredientList.instance.ingredient["ing6"];
                ingredient[1] = IngredientList.instance.ingredient["ing7"];
                ingredient[2] = IngredientList.instance.ingredient["ing8"];
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
