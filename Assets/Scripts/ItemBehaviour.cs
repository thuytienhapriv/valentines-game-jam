using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemBehaviour : MonoBehaviour, IPointerDownHandler
{
    public GameObject item;
    //private GameObject inventoryIcon;
    private List<Transform> slotPos = new List<Transform> { };
    private List<GameObject> itemCopies = new List<GameObject> { };

    public void Awake()
    {
        if (item == null) { item = gameObject; }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("clicked");

        if (CheckIfFull() == false) 
        {
            // put into first empty slot
            int slotNum = FindFirstEmpty();
            slotPos.Add(Inventory.instance.inventorySlot[slotNum].transform); // slotPos -> where the icon will show
            Inventory.instance.inInventory[slotNum] = true;
            Inventory.instance.isEmpty[slotNum] = false;

            Debug.Log(slotNum + " " + Inventory.instance.inventorySlot[slotNum].name);

            GameObject inventoryIcon = new GameObject();
            itemCopies.Add(inventoryIcon);
            inventoryIcon = Instantiate(item, Inventory.instance.inventorySlot[slotNum].transform);
            inventoryIcon.GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
            inventoryIcon.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            
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
                Debug.Log("first empty is " + i);
                result = i;
                return result;
            }
        }
        return result;
    }

    void Update()
    {
        
            int place = 0;
            foreach (var item in itemCopies)
            {
                

                item.transform.position = Inventory.instance.inventorySlot[place].transform.position;
                place++;
                // instantiate the copy onto the position
            }
        
    
    }
}
