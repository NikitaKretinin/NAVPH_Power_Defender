using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;

public class GlobalInventoryBehaviour : MonoBehaviour
{
  private GlobalInventory globalInventory = null;

  public GlobalInventory GetGlobalInventory()
  {
    return globalInventory;
  }

  private void LoadGlobalInventory()
  {
    if (File.Exists(Application.persistentDataPath + "/GlobalInventory.json"))
    {
      globalInventory = JsonUtility.FromJson<GlobalInventory>(
        File.ReadAllText(Application.persistentDataPath + "/GlobalInventory.json")
      );
    }
    else
    {
      globalInventory = new GlobalInventory
      {
        unlockedPlants = new List<GenericPlant> {
          new GenericPlant
          {
            name = "Plant1",
            ripeTime = 6,
            imageIndex = 67,
            isUnlocked = true,
          },
          new GenericPlant
          {
            name = "Plant2",
            ripeTime = 5,
            imageIndex = 56,
            isUnlocked = false,
          },
          new GenericPlant
          {
            name = "Plant3",
            ripeTime = 2,
            imageIndex = 55,
            isUnlocked = false,
          },
          new GenericPlant
          {
            name = "Plant4",
            ripeTime = 3,
            imageIndex = 52,
            isUnlocked = false,
          },
          new GenericPlant
          {
            name = "Plant5",
            ripeTime = 7,
            imageIndex = 68,
            isUnlocked = false,
          }
        },
        availableMaps = 0,
      };
      SaveGlobalInventory();
    }
    Debug.Log("Loaded global inventory");
    Debug.Log(globalInventory);
  }

  public void SaveGlobalInventory()
  {
    string json = JsonUtility.ToJson(globalInventory);
    File.WriteAllText(Application.persistentDataPath + "/GlobalInventory.json", json);
  }

  public void UnlockNextPlant()
  {
    globalInventory = JsonUtility.FromJson<GlobalInventory>(
        File.ReadAllText(Application.persistentDataPath + "/GlobalInventory.json")
      );
    var firstMatch = globalInventory.unlockedPlants.FirstOrDefault(s => s.isUnlocked == false);
    if(firstMatch != null)
    {
      firstMatch.isUnlocked = true;
    }
    SaveGlobalInventory();
  }

  public void AddMap()
  {
    globalInventory = JsonUtility.FromJson<GlobalInventory>(
        File.ReadAllText(Application.persistentDataPath + "/GlobalInventory.json")
      );
    globalInventory.availableMaps++;
    SaveGlobalInventory();
  }

  private void Start()
  {
    LoadGlobalInventory();
  }
}