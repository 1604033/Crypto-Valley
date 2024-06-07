using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Inventory/Item Data", order = 50)]
public class ItemData : ScriptableObject
{
    new public string itemName = "Item Name";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}
