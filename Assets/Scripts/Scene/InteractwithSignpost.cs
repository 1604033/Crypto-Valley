using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractwithSignpost : MonoBehaviour
{
    public GameObject popup;

    private void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera through the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the game object
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is the game object with the collider
                if (hit.collider.gameObject == gameObject)
                {
                    // Show the popup
                    if (popup != null)
                    {
                        popup.SetActive(true);
                    }
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Hide the popup when the mouse button is released
            if (popup != null)
            {
                popup.SetActive(false);
            }
        }
    }
}
