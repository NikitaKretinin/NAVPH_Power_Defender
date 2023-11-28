using UnityEngine;
using System.IO;
using System.Collections.Generic;
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
        plants = new List<GenericPlant> {
          new() {
            name = "Plant1",
            id = "plant1",
            ripeTime = 6,
            imageIndex = 67,
            isUnlocked = true,
            ability = Effect.Heal
          },
          new() {
            name = "Plant2",
            id = "plant2",
            ripeTime = 5,
            imageIndex = 56,
            isUnlocked = false,
            ability = Effect.AttackUp
          },
          new() {
            name = "Plant3",
            id = "plant3",
            ripeTime = 2,
            imageIndex = 55,
            isUnlocked = false,
            ability = Effect.SpeedUp
          },
          new() {
            name = "Plant4",
            id = "plant4",
            ripeTime = 3,
            imageIndex = 52,
            isUnlocked = false,
            ability = Effect.AttackEnemiesDown
          },
          new() {
            name = "Plant5",
            id = "plant5",
            ripeTime = 7,
            imageIndex = 68,
            isUnlocked = false,
            ability = Effect.SpeedEnemiesDown
          }
        },
        availableMaps = 0,
        prevAttackLevel = 0
      };
      SaveGlobalInventory();
    }
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
    var firstMatch = globalInventory.plants.FirstOrDefault(s => s.isUnlocked == false);
    if (firstMatch != null)
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

  private void Awake()
  {
    LoadGlobalInventory();
  }
}