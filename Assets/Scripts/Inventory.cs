using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public Image[] inventorySlot;
    public bool[] isEmpty;
    public GameObject[] inInventory;
    public bool mouseHoversInventory;


    private void Awake()
    {
        if (instance == null) { instance = this; }
        mouseHoversInventory = false;
    }

    void Start()
    {
        isEmpty = new bool[inventorySlot.Length];
        inInventory = new GameObject[inventorySlot.Length];

        for (int i = 0; i < inventorySlot.Length; i++)
        {
            isEmpty[i] = true;
            inInventory[1] = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
