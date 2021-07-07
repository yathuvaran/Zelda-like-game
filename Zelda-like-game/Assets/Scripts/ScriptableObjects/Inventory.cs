using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKeys;

    public void AddItem(Item itemToAdd)
    {
        //Is the item a key?
        if (itemToAdd.isKey)
        {
            numberOfKeys++;
        }
        else
        {
            // if it is not already in our list of items 
            if (!items.Contains(itemToAdd))
            {
                items.Add(itemToAdd);
            }
        }
    }
}
