using UnityEngine;
using System.Collections.Generic;

public class InventorySystem : MonoBehaviour
{
    public int maxItems = 20; // Maximum number of items in the inventory
    private List<Item> itemList; // List to store items in the inventory
    public ItemSlot[] itemSlots; // UI slots for inventory

    private void Awake()
    {
        itemList = new List<Item>(); // Initialize item list
        InitializeItemSlots(); // Setup UI slots
    }

    private void InitializeItemSlots()
    {
        // Initialize the UI slots.
        // This could involve linking UI elements to item slots
    }

    // Method to add an item to the inventory
    public bool AddItem(Item item)
    {
        if (itemList.Count >= maxItems)
        {
            Debug.Log("Inventory full!");
            return false; // Inventory is full
        }
        itemList.Add(item);
        UpdateUI(); // Update UI after adding item
        return true;
    }

    // Method to remove an item from the inventory
    public void RemoveItem(Item item)
    {
        if (itemList.Remove(item))
        {
            UpdateUI(); // Update UI after removing item
        }
        else
        {
            Debug.Log("Item not found in inventory.");
        }
    }

    // Update the inventory UI to reflect the current items
    private void UpdateUI()
    {
        // Iterate through item slots and update each one based on the current inventory
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (i < itemList.Count)
            {
                itemSlots[i].SetItem(itemList[i]); // Assume SetItem updates the UI slot
            }
            else
            {
                itemSlots[i].ClearSlot(); // Clear slot if no item
            }
        }
    }
}

// Example item and item slot classes
[System.Serializable]
public class Item
{
    public string itemName;
    public int amount;
}

public class ItemSlot : MonoBehaviour
{
    public void SetItem(Item item)
    {
        // Update UI to represent the item
    }

    public void ClearSlot()
    {
        // Clear the UI for this slot
    }
}