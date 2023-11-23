using System.Collections.Generic;
using UnityEngine;

public class PlantSelection : MonoBehaviour
{
  private List<GenericPlant> availablePlants = null;
  private GlobalInventory globalInventory = null;
  GameObject[] selectedPlantSlots = null;


  private void Start()
  {
    globalInventory = GameObject.Find("GlobalInventory").GetComponent<GlobalInventoryBehaviour>().GetGlobalInventory();
    availablePlants = globalInventory.unlockedPlants;
    Debug.Log("availablePlants: " + availablePlants);

    GameObject[] availablePlantSlots = GameObject.FindGameObjectsWithTag("AvailablePlantSlot");

    for (int i = 0; i < availablePlantSlots.Length; i++)
    {
      // add images to available plant slots
    }
  }
}