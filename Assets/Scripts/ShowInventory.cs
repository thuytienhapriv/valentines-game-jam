using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventory : MonoBehaviour
{
    public GameObject recipeBook;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public float pagenumber;

    private void Start()
    {
        pagenumber = 1;
    }

    public void ShowBook()
    {
        recipeBook.SetActive(true);
    }

    public void CloseBook()
    {
        recipeBook.SetActive(false);
    }

    public void MinusPage()
    {
        if (pagenumber > 1)
        {
            pagenumber -= 1;
        }
    }

    public void PlusPage()
    {
        if (pagenumber < 3) 
        {  pagenumber += 1;}
    }

    void Update()
    {
        if (pagenumber == 1)
        {
            page1.SetActive(true);
            page2.SetActive(false);
            page3.SetActive(false);
        } else if (pagenumber == 2 )
        {
            page1.SetActive(false);
            page2.SetActive(true);
            page3.SetActive(false);
        } else if (pagenumber == 3 )
        {
            page1.SetActive(false);
            page2.SetActive(false);
            page3.SetActive(true);
        }
    }
}
