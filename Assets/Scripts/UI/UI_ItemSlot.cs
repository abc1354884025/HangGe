using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ItemSlot : MonoBehaviour
{
    private UI ui;
    [SerializeField] protected Image itemImage;
    [SerializeField] protected TextMeshProUGUI itemText;
    [SerializeField] protected ItemData item;
    protected virtual void Start()
    {
        ui=GetComponentInParent<UI>();
    }
    public void UpdateSlot(ItemData item)
    {
        this.item = item;
        if (item != null)
        {
            itemImage.sprite = item.itemIcon;
        }
    }
}
