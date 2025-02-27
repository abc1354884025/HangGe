using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public enum ItemType
{
    Material,
    Equipment
}
[System.Serializable]
public class ItemData
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemIcon;
    public int id;
    //µôÂä¼¸ÂÊ
    public int dropChance;


}
