using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverInventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Inventory.instance.mouseHoversInventory = true;
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        Inventory.instance.mouseHoversInventory = false;
    }
}
