using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class InventoryItem
{
    public ItemData data;
    public int stackSize;
    public InventoryItem(ItemData itemData)
    {
        this.data = itemData;
        AddStack();
    }
    public void AddStack(int num = 1) => stackSize += num;
    public void RemoveStack(int num = 1) => stackSize -= num;
}