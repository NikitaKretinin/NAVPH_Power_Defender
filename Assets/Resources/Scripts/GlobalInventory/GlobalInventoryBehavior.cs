using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;

public class GlobalInventoryBehaviour : MonoBehaviour
{
  private GlobalInventory globalInventory = null;

  public GlobalInventory GetGlobalInventory()
  {
    return globalInventory;
  }

  private void LoadGlobalInventory()
  {
    try
    {
      globalInventory = JsonUtility.FromJson<GlobalInventory>(
        File.ReadAllText(Application.persistentDataPath + "/GlobalInventory.json")
      );
    }
    catch (Exception)
    {
      globalInventory = new GlobalInventory
      {
        unlockedPlants = new HashSet<string> { "plant1" },
      };
      SaveGlobalInventory();
    }
  }

  public void SaveGlobalInventory()
  {
    string json = JsonUtility.ToJson(globalInventory);
    File.WriteAllText(Application.persistentDataPath + "/GlobalInventory.json", json);
  }

  public void AddPlant(string plantName)
  {
    globalInventory.unlockedPlants.Add(plantName);
    SaveGlobalInventory();
  }

  public void AddMap(string mapName)
  {
    globalInventory.availableMaps.Add(mapName);
    SaveGlobalInventory();
  }

  private void Start()
  {
    LoadGlobalInventory();
  }
}