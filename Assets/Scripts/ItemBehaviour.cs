using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemBehaviour : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public GameObject item;
    [SerializeField] private Image inventoryBounds;
    
    private float scaleDown = 0.2f;
    private float potionScale = 0.1f;

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

            Debug.Log(slotNum + " " + Inventory.instance.inventorySlot[slotNum].name);

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
            item.GetComponent<Image>().raycastTarget = true;

            if (Inventory.instance.mouseHoversInventory == true)
            {
                if (IngredientList.instance.mouseHoversCauldron == false)
                {
                    Debug.Log("mouse aint over cauldron");
                    int ind = 0;
                    for (int i = 0; i < Inventory.instance.inInventory.Length; ++i)
                    {
                        if (Inventory.instance.inInventory[i] == item)
                        {
                            i = ind; break;
                        }
                    }
                    Debug.Log(ind);
                    item.transform.position = Inventory.instance.inventorySlot[ind].transform.position;
                    item.transform.localPosition = Vector3.zero;
                } 
                else
                {
                    Debug.Log("add to soup !!!");
                    int ind = 0;
                    for (int i = 0; i < Inventory.instance.inInventory.Length; ++i)
                    {
                        if (Inventory.instance.inInventory[i] == item)
                        {
                            Inventory.instance.isEmpty[i] = true;
                            Inventory.instance.inInventory[i] = null;
                            i = ind; break;
                        }
                    }
                    
                    int ingNum = FindFirstInPotion();
                    IngredientList.instance.inPotion[ingNum] = item;
                    item.tag = "ItemInCauldron";
                    item.transform.position = IngredientList.instance.potionSlot[ingNum].transform.position;
                    item.transform.localScale = new Vector3(potionScale, potionScale, potionScale);
                }
            }
            else
            {
                for (int i = 0; i < Inventory.instance.inInventory.Length; ++i)
                {
                    if (Inventory.instance.inInventory[i] == item)
                    {
                        Inventory.instance.isEmpty[i] = true;
                        Inventory.instance.inInventory[i] = null; break;
                    }
                }
                Destroy(item);
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
                return result;
            }
        }
        return result;
    }
}
