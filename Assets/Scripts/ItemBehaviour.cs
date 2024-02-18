using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemBehaviour : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public GameObject item;    
    private float scaleDown = 0.5f;
    private float potionScale = 0.5f;

    public enum ingredient { in1, in2, in3, in4, in5, in6, in7, in8, in9 }
    public ingredient ingredientName;

    public void OnEnable()
    {
        if (item == null) { item = gameObject; }
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("clicked");

        if (CheckIfFull() == false && item.CompareTag("ItemInScene")) 
        {
            
            int slotNum = FindFirstEmpty(); // put into first empty slot
            Inventory.instance.isEmpty[slotNum] = false;

            //Debug.Log(slotNum + " " + Inventory.instance.inventorySlot[slotNum].name);

            GameObject inventoryIcon = Instantiate(item, Inventory.instance.inventorySlot[slotNum].transform);
            Inventory.instance.inInventory[slotNum] = inventoryIcon;

            inventoryIcon.tag = "ItemInInventory";
            inventoryIcon.GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
            //inventoryIcon.transform.position = Inventory.instance.inventorySlot[slotNum].transform.position;
            inventoryIcon.transform.localPosition = Vector3.zero;
            inventoryIcon.transform.localScale = new Vector3(scaleDown, scaleDown, scaleDown);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item.CompareTag("ItemInInventory"))
        {
            item.GetComponent<Image>().raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item.CompareTag("ItemInInventory")) {

            Vector3 dragPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            item.transform.position = dragPos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (item.CompareTag("ItemInInventory"))
        {
            int ind = 0;
            string parentName = item.transform.parent.name;
            for (int i = 0; i < Inventory.instance.inventorySlot.Length; ++i)
            {
                //Debug.Log(Inventory.instance.inventorySlot[i].name);
                if (Inventory.instance.inventorySlot[i].name == parentName)
                {
                    ind = i; break;
                }
            }

            //Debug.Log("parent is in slot nr " + ind);

            item.GetComponent<Image>().raycastTarget = true;

            if (Inventory.instance.mouseHoversInventory == false)
            {

                if (IngredientList.instance.mouseHoversCauldron == true)
                {
                    // if on cauldron - add to soup
                    //Debug.Log("add to soup !!!");

                    Inventory.instance.isEmpty[ind] = true;
                    Inventory.instance.inInventory[ind] = null;
                    
                    int ingNum = FindFirstInPotion();
                    
                    IngredientList.instance.inPotion[ingNum] = CorrespondingGO();
                    item.tag = "ItemInCauldron";
                    item.transform.position = IngredientList.instance.potionSlot[ingNum].transform.position;
                    item.transform.localScale = new Vector3(potionScale, potionScale, potionScale);

                    if (ingNum == 2)
                    {
                        // making potion // checkPotion returns IsGood
                        if (IngredientList.instance.CheckPotion() == false) 
                        {
                            GameManager.instance.Lose(); // you lose the game
                        } else
                        {
                            GameManager.instance.NextClient();
                            Timer.instance.timeRemaining = Timer.instance.maxTime;
                        }

                        // destroy the small cauldron icons
                        foreach (var gameObj in GameObject.FindGameObjectsWithTag("ItemInCauldron"))
                        {
                            Destroy(gameObj);
                        }

                        for (int i=0; i < IngredientList.instance.inPotion.Length; i++)
                        {
                            IngredientList.instance.inPotion[i] = null;
                        }
                    }
                }
                else
                {
                    // if anywhere, destroy
                    Inventory.instance.isEmpty[ind] = true;
                    Inventory.instance.inInventory[ind] = null;
                    Destroy(item);
                }

            }
            else
            {
                // if on inventory
                Debug.Log("mouse aint over cauldron or inventory");
                
                item.transform.position = Inventory.instance.inventorySlot[ind].transform.position;
                item.transform.localPosition = Vector3.zero;
            }
        }
    }
    

    private bool CheckIfFull()
    {
        bool isFull = true;
        for (int i = 0; i < Inventory.instance.isEmpty.Length; i++)
        {
            if (Inventory.instance.isEmpty[i] == true)
            {
                isFull = false;
            }

        }
        return isFull;
    }

    private int FindFirstEmpty()
    {
        int result = 0;
        for (int i = 0; i < Inventory.instance.isEmpty.Length; i++)
        {
            if (Inventory.instance.isEmpty[i] == true)
            {
                result = i;
                return result;
            }
        }
        return result;
    }

    private int FindFirstInPotion()
    {
        int result = 0;
        for (int i = 0; i < IngredientList.instance.inPotion.Length; i++)
        {
            if (IngredientList.instance.inPotion[i] == null)
            {
                result = i;
                //Debug.Log("ing in potion nr " + result);

                return result;
            }
        }
        return result;
    }

    private GameObject CorrespondingGO()
    {
        if (this.ingredientName == ingredient.in1) { return IngredientList.instance.ingredient["ing1"]; }
        if (this.ingredientName == ingredient.in2) { return IngredientList.instance.ingredient["ing2"]; }
        if (this.ingredientName == ingredient.in3) { return IngredientList.instance.ingredient["ing3"]; }
        if (this.ingredientName == ingredient.in4) { return IngredientList.instance.ingredient["ing4"]; }
        if (this.ingredientName == ingredient.in5) { return IngredientList.instance.ingredient["ing5"]; }
        if (this.ingredientName == ingredient.in6) { return IngredientList.instance.ingredient["ing6"]; }
        if (this.ingredientName == ingredient.in7) { return IngredientList.instance.ingredient["ing7"]; }
        if (this.ingredientName == ingredient.in8) { return IngredientList.instance.ingredient["ing8"]; }
        if (this.ingredientName == ingredient.in9) { return IngredientList.instance.ingredient["ing9"]; }


        return null;
    }
}
