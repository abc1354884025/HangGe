using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour,ISaveManager
{
    public static Inventory instance;
    //已装备的装备  
    public List<ItemData_Equipment> equipment = new List<ItemData_Equipment>();

    //装备背包
    public List<ItemData_Equipment> equipmentInventory = new List<ItemData_Equipment>();

    //材料背包
    public List<InventoryItem> stash = new List<InventoryItem>();
    public Dictionary<ItemData, InventoryItem> stashItemDictionary = new Dictionary<ItemData, InventoryItem>();

    [Header("InventoryUI")]
    [SerializeField] private Transform invenventorySlotParent;
    [SerializeField] private Transform stashSlotParent;
    [SerializeField] private Transform equipmentSlotParent;


    private UI_ItemSlot[] itemItemSlots;
    private UI_ItemSlot[] stashItemSlots;
    private UI_EquipmentSlot[] equipmentItemSlots;
    private UI_StatSlot[] statSlot;
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
    private void Start()
    {

    }


    public void AddItem(ItemData item)
    {
        if(item.itemType == ItemType.Equipment && CanAddItem())
        {
            AddToInventory(item);
        }else if(item.itemType == ItemType.Material)
        {
            AddToStash(item);
        }
    }
    /// <summary>
    /// 物品是否上限
    /// </summary>
    /// <returns></returns>
    public bool CanAddItem()
    {
        if (equipmentInventory.Count >= itemItemSlots.Length)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// 添加到装备背包
    /// </summary>
    /// <param name="item"></param>
    private void AddToInventory(ItemData item)
    {
        equipmentInventory.Add(item as ItemData_Equipment);
    }

    /// <summary>
    /// 添加到材料背包
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
    /// 移除物品
    /// </summary>
    /// <param name="item"></param>
    public void RemoveItem(ItemData item)
    {
        if (item.itemType == ItemType.Equipment)
        {

            for (int i = 0; i < equipmentInventory.Count; i++)
            {
                if(equipmentInventory[i] == item)
                {
                    equipmentInventory.RemoveAt(i);
                }
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

    public void LoadData(GameData data)
    {
        throw new System.NotImplementedException();
    }

    public void SaveData(ref GameData data)
    {
        throw new System.NotImplementedException();
    }
}
