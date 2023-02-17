using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_InventoryMain : MonoBehaviour
{
    [SerializeField] private List<string> _inventoryItems = new List<string>();

    public static P_InventoryMain Instance { get; private set; }
    private void Awake()
    {
        if(Instance != null && Instance != this) Destroy(Instance);
        else Instance = this;
    }

    public void AddItem(GameObject item) => _inventoryItems.Add(item.gameObject.name);

}
