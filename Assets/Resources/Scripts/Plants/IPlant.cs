using UnityEngine;

public interface IPlant
{
    // Property to represent the amount of a plant
    int Amount { get; set; }
    int RipeTime { get; set; }

    public int ImageIndex { get; }

    // Method to activate consumption of the plant
    bool Consume();

    // Method to add a plant to the inventory
    void AddToInventory();
}
