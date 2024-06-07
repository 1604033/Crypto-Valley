using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Player player;
    public List<Slot_UI> slots = new List<Slot_UI>();
    [SerializeField] private Canvas canvas;
    
    private Slot_UI draggedSlot;
    private Image draggedIcon;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }

    private void Start()
    {
        SetupSlots();
        Refresh();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if(!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Debug.Log("toggling");
            Refresh();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    public void Refresh()
    {
       if(slots.Count == player.inventory.slots.Count)
       {
        for(int i = 0; i < slots.Count; i++)
        {
            if(player.inventory.slots[i].itemName != "")
            {
                slots[i].SetItem(player.inventory.slots[i]);
                Debug.Log("Refreshing");
            }
            else
            {
                slots[i].SetEmpty();
            }
        }
       }
    }

    public void SlotBeginDrag(Slot_UI slot)
    {
        
        draggedSlot = slot;
        draggedIcon = Instantiate(draggedSlot.itemIcon);
        draggedIcon.transform.SetParent(canvas.transform);
        draggedIcon.raycastTarget = false;
        draggedIcon.rectTransform.sizeDelta = new Vector2(40,40);
        MoveToMousePosition(draggedIcon.gameObject);
        Debug.Log("Start Drag: " + draggedSlot.name);

    }

    public void SlotDrag()
    {
        MoveToMousePosition(draggedIcon.gameObject);
        Debug.Log("Draging: " + draggedSlot.name);
    }

    public void SlotEndDrag()
    {
       Debug.Log("Dragged ok: " + draggedSlot.name);
       Destroy(draggedIcon.gameObject);
       draggedIcon = null;
    
    }

    public void SlotDrop(Slot_UI slot)
    {
        player.inventory.MoveSlot(draggedSlot.slotID, slot.slotID);
        Debug.Log("Drop: " + draggedSlot.name);
        Refresh();
        
    }

    private void MoveToMousePosition(GameObject toMove)
    {
        if(canvas != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
            toMove.transform.position = canvas.transform.TransformPoint(position);
        }
    }

    void SetupSlots()
    {
        int counter = 0;
        foreach(Slot_UI slot in slots)
        {
            slot.slotID = counter;
            counter++;
        }
    }
}
