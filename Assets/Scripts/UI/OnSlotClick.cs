using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnSlotClick : MonoBehaviour
{
    public GameObject popupUI; // The popup UI to show
    public Item currentItem; // The current item in the slot

    private void Start()
    {
        // Ensure the popup UI is initially inactive
        if (popupUI != null)
        {
            popupUI.SetActive(false);
        }
    }

    public void SetItem(Item newItem)
    {
        currentItem = newItem;
    }

    public void SlotClick()
    {
        if (currentItem != null && currentItem.itemName == "Seed")
        {
            // Show the popup UI
            if (popupUI != null)
            {
                popupUI.SetActive(true);
                Debug.Log("clicking");
            }
        }
    }

    /*private void Update()
    {
        // Hide the popup UI if it's active and the player clicks elsewhere
        if (popupUI != null && popupUI.activeSelf && Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera through the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits a UI element
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == null || hit.collider.gameObject != gameObject)
                {
                    popupUI.SetActive(false);
                }
            }
        }
    }*/
}
