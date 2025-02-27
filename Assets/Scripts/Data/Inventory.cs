using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    //���ϵ�װ��
    public List<InventoryItem> equipment = new List<InventoryItem>();
    public Dictionary<ItemData_Equipment, InventoryItem> equipmentDictionary = new Dictionary<ItemData_Equipment, InventoryItem>();
    //װ���ֿ�
    public List<InventoryItem> inventory = new List<InventoryItem>();
    public Dictionary<ItemData, InventoryItem> inventoryItemDictionary = new Dictionary<ItemData, InventoryItem>();
    //���ϲֿ�
    public List<InventoryItem> stash = new List<InventoryItem>();
    public Dictionary<ItemData, InventoryItem> stashItemDictionary = new Dictionary<ItemData, InventoryItem>();



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// ����װ��������
    /// </summary>
    /// <param name="item"></param>
    private void AddToInventory(ItemData item)
    {
        if (inventoryItemDictionary.TryGetValue(item, out InventoryItem inventoryItem))
        {
            inventoryItem.AddStack();
        }
        else
        {
            InventoryItem newInventoryItem = new InventoryItem(item);
            inventory.Add(newInventoryItem);
            inventoryItemDictionary.Add(item, newInventoryItem);
        }
    }

    /// <summary>
    /// ���Ӳ��ϵ��ֿ�
    /// </summary>
    /// <param name="item"></param>
    public void AddToStash(ItemData item)
    {
        if (stashItemDictionary.TryGetValue(item, out InventoryItem inventoryItem))
        {
            inventoryItem.AddStack();
        }
        else
        {
            InventoryItem newInventoryItem = new InventoryItem(item);
            stash.Add(newInventoryItem);
            stashItemDictionary.Add(item, newInventoryItem);
        }
    }

    /// <summary>
    /// ������Ʒ
    /// </summary>
    /// <param name="item"></param>
    public void RemoveItem(ItemData item)
    {
        if (inventoryItemDictionary.TryGetValue(item, out InventoryItem inventoryItem))
        {

            if (inventoryItem.stackSize <= 1)
            {
                inventory.Remove(inventoryItem);
                inventoryItemDictionary.Remove(item);
            }
            else
            {
                inventoryItem.RemoveStack();
            }
        }
        if (stashItemDictionary.TryGetValue(item, out InventoryItem stashItem))
        {

            if (stashItem.stackSize <= 1)
            {
                stash.Remove(stashItem);
                stashItemDictionary.Remove(item);
            }
            else
            {
                stashItem.RemoveStack();
            }
        }
        //UpdateSlotUI();
    }



}
