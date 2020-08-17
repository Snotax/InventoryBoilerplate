using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UIInventory class
/// This should not be used in production. It is only to demonstrate how it could be done
/// Author: Yannick Laubscher
/// Date: 16.08.2020
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Inventory Item")]
    public Inventory Inventory;

    private Camera main;

    private PickupHandler lastHandler;

    private void Start()
    {
        main = Camera.main;
    }
    void Update()
    {
        CheckForInteract();
    }

    private void CheckForInteract()
    {
        RaycastHit hit;
        var ray = main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        if (Physics.Raycast(ray, out hit, 10))
        {
            if (hit.collider.gameObject.GetComponent<PickupHandler>())
            {
                var ph = hit.collider.gameObject.GetComponent<PickupHandler>();
                lastHandler = ph;
                ph.DisplayText();
                if ((Input.GetKey(KeyCode.E)))
                {
                    Inventory.AddItem(ph.Item);
                    Destroy(hit.collider.gameObject);
                }
            }
            else
            {
                lastHandler.HideText();
            }
        }
    }
}
