using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{
    public int slotID;
    public Image itemIcon;
    public TextMeshProUGUI quantityText;
    //public ItemData itemData;
    public string itemName;
    public GameObject popupUI;

    public void SetItem(Inventory.Slot slot)
    {
        if(slot != null)
        {
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1,1,1,1);
            itemName = slot.itemName;
            // How I can inherit Item data
            //itemData = item.data;
            //Debug.Log(itemName);
            //quantityText.text = slot.count.ToString();
        }
    }

    public void SetEmpty()
    {
        itemIcon.sprite = null;
        itemIcon.color = new Color(1,1,1,0);
        //quantityText.text ="";
    }

    /*public void OnSlotClick()
    {
        string a = itemData.itemName;
        Debug.Log(a);
        if (itemData.itemName != null)
        {
            //Item itemComponent = item.GetComponent<Item>();
            if (itemData.itemName == "Seed Package")
            {
                // Show the popup UI
                if (popupUI != null)
                {
                    popupUI.SetActive(true);
                }
            }
        }
    }*/

    public void OnClick()
    {
        if(itemName == "Seed Package")
        {
            if (popupUI != null)
                {
                    popupUI.SetActive(true);
                }
        }
    }

}
