using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemBehaviour : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public GameObject item;
    [SerializeField] private Canvas canvas;
    private List<Transform> slotPos = new List<Transform> { };
    private List<GameObject> itemCopies = new List<GameObject> { };
    private float scaleDown = 0.2f;

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
            // put into first empty slot
            int slotNum = FindFirstEmpty();
            slotPos.Add(Inventory.instance.inventorySlot[slotNum].transform);
            slotPos.Add(Inventory.instance.inventorySlot[slotNum].transform); // slotPos -> where the icon will show
            Inventory.instance.inInventory[slotNum] = true;
            Inventory.instance.isEmpty[slotNum] = false;

            Debug.Log(slotNum + " " + Inventory.instance.inventorySlot[slotNum].name);

            GameObject inventoryIcon = new GameObject();

            itemCopies.Add(inventoryIcon);

            inventoryIcon = Instantiate(item, Inventory.instance.inventorySlot[slotNum].transform);
            
            //inventoryIcon.transform.position = Vector3(0, 0, 0);
            //inventoryIcon.transform.SetParent(Inventory.instance.inventorySlot[slotNum].transform);


            inventoryIcon.GetComponent<Image>().sprite = item.GetComponent<Image>().sprite;
            inventoryIcon.tag = "ItemInInventory";
            inventoryIcon.transform.localPosition = Vector3.zero;
            inventoryIcon.transform.localScale = new Vector3(scaleDown, scaleDown, scaleDown);
            
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item.CompareTag("ItemInInventory")) {
            Vector3 dragPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            item.transform.position = dragPos;
            
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
                

                //item.transform.position = new Vector3 (0, 0, 0);

                place++;
                // instantiate the copy onto the position
            }
        
    
    }
}
