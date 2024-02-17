using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverCauldron : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        IngredientList.instance.mouseHoversCauldron = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IngredientList.instance.mouseHoversCauldron = false;
    }
}
