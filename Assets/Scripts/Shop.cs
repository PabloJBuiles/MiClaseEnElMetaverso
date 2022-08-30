using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]private GameObject[] items;
    [SerializeField]private GameObject[] Characters;

    private List<bool> itemsOwned = new List<bool>();
    private int idItemToBuy;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            itemsOwned.Add(false);
        }
    }

    public void SetItemID(int itemID)
    {
        idItemToBuy = itemID;
    }

    public void BuyItem(int itemPrice)
    {
        if (GameManager.BuyItem(itemPrice))
        {
            items[idItemToBuy].SetActive(true);
            itemsOwned[idItemToBuy] = true;
            //TODO efectos visuales cuando aparese el item
        }
        else
        {
            //TODO dar feedback de que no hay plata
        }
    }
    
}
